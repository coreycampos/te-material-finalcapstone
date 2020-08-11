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
        private string sqlSelectAllHarvests = "SELECT harvest_id, harvests.crop_id , crops.crop_name, area_identifier, weight_count, date_harvested FROM harvests INNER JOIN crops ON crops.crop_id=harvests.crop_id;";
        private string sqlAddNewHarvest = "INSERT INTO harvests (crop_id, area_identifier, weight_count, date_harvested) VALUES (@cropId, @area, @weight, @dateHarvested)";

        public HarvestSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Harvest> GetAllHarvests()
        {
            List<Harvest> harvestList = new List<Harvest>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllHarvests, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Harvest currentHarvest = new Harvest();

                    currentHarvest.harvestId = Convert.ToInt32(reader["harvest_id"]);
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

        public bool AddNewHarvest(Harvest newHarvest)
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
    }
}
