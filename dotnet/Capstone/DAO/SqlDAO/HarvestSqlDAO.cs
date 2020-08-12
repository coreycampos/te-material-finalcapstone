using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class HarvestSqlDAO : IHarvestDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllHarvests = "SELECT harvest_id, inventory_id, harvests.crop_id , crops.crop_name, area_identifier, weight_count, date_harvested FROM harvests INNER JOIN crops ON crops.crop_id=harvests.crop_id;";
        private string sqlSelectSpecificHarvest = "SELECT harvest_id, harvests.crop_id , crops.crop_name, area_identifier, weight_count, date_harvested FROM harvests INNER JOIN crops ON crops.crop_id=harvests.crop_id WHERE harvest_id = @harvestId;";
        private string sqlAddNewHarvest = "INSERT INTO harvests (crop_id, area_identifier, weight_count, date_harvested, inventory_id) VALUES (@cropId, @area, @weight, @dateHarvested, @inventoryId)";
        private string sqlExpiringWithinWeek = "SELECT * FROM harvests AS h JOIN crops AS c ON h.crop_id = c.crop_id "
+ "WHERE DATEDIFF(day, DATEADD(day, c.time_to_expire, h.date_harvested), GETDATE()) <= 7;";
        private string sqlUpdateHarvest = "UPDATE harvests SET crop_id = @cropId, area_identifier = @area, weight_count = @amount, date_harvested = @dateHarvested WHERE harvest_id = @harvestId;";
        private string sqlGetCropId = "SELECT crop_id FROM crops WHERE crop_name = @cropName;";


        public HarvestSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Harvest> GenericSelectHarvest(string sqlCommand)
        {
            List<Harvest> harvestList = new List<Harvest>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlCommand, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Harvest currentHarvest = new Harvest();

                    currentHarvest.harvestId = Convert.ToInt32(reader["harvest_id"]);
                    currentHarvest.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentHarvest.cropID = Convert.ToInt32(reader["crop_id"]);
                    currentHarvest.cropName = Convert.ToString(reader["crop_name"]);
                    currentHarvest.area = Convert.ToString(reader["area_identifier"]);
                    currentHarvest.weight = Convert.ToDecimal(reader["weight_count"]);
                    currentHarvest.dateHarvested = Convert.ToDateTime(reader["date_harvested"]);

                    harvestList.Add(currentHarvest);
                }

                return harvestList;
            }
        } 

        public List<Harvest> GetAllHarvests()
        {
            return GenericSelectHarvest(sqlSelectAllHarvests);
        }

        public Harvest GetSpecificHarvest(int harvestId)
        {
            Harvest currentHarvest = new Harvest();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectSpecificHarvest, conn);
                cmd.Parameters.AddWithValue("@harvestId", harvestId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    currentHarvest.harvestId = Convert.ToInt32(reader["harvest_id"]);
                    currentHarvest.cropID = Convert.ToInt32(reader["crop_id"]);
                    currentHarvest.cropName = Convert.ToString(reader["crop_name"]);
                    currentHarvest.area = Convert.ToString(reader["area_identifier"]);
                    currentHarvest.weight = Convert.ToDecimal(reader["weight_count"]);
                    currentHarvest.dateHarvested = Convert.ToDateTime(reader["date_harvested"]);
                }
                return currentHarvest;
            }
        }
        public bool AddNewHarvest(Harvest newHarvest, int inventoryId)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddNewHarvest, conn);
                    cmd.Parameters.AddWithValue("@cropId", newHarvest.cropID);
                    cmd.Parameters.AddWithValue("@area", newHarvest.area);
                    cmd.Parameters.AddWithValue("@weight", newHarvest.weight);
                    cmd.Parameters.AddWithValue("@dateHarvested", newHarvest.dateHarvested);
                    cmd.Parameters.AddWithValue("@inventoryId", inventoryId);

                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool UpdateHarvest(Harvest someHarvest)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand gettingCropId = new SqlCommand(sqlGetCropId, conn);
                    gettingCropId.Parameters.AddWithValue("@cropName", someHarvest.cropName);
                    object cropId = gettingCropId.ExecuteScalar();

                    SqlCommand cmd = new SqlCommand(sqlUpdateHarvest, conn);
                    cmd.Parameters.AddWithValue("@planId", someHarvest.harvestId);
                    cmd.Parameters.AddWithValue("@cropId", cropId);
                    cmd.Parameters.AddWithValue("@area", someHarvest.area);
                    cmd.Parameters.AddWithValue("@dateHarvested", someHarvest.dateHarvested);
                    cmd.Parameters.AddWithValue("@amount", someHarvest.weight);
                    cmd.ExecuteNonQuery();
                }
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = false;
            }
            return result;
        }
        public int GetCropId(string cropName)
        {
            int cropId = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand gettingCropId = new SqlCommand(sqlGetCropId, conn);
                    gettingCropId.Parameters.AddWithValue("@cropName", cropName);
                    cropId = (int)gettingCropId.ExecuteScalar();

                    return cropId;
                }
            }
            catch(Exception e)
            {
                return cropId;
            }
        }

        public List<Harvest> ExpiringWithinWeek()
        {
            return GenericSelectHarvest(sqlExpiringWithinWeek);
        }
    }
}
