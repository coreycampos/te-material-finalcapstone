using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class CropSqlDAO : ICropDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllCrops = "SELECT * FROM crops";
        private string sqlUpdateCrop = "IF EXISTS (SELECT * FROM crops WHERE crop_name = @cropName) " +
            "BEGIN UPDATE crops SET time_seed_to_transplant = @newST, time_transplant_to_harvest = @newTH, " +
            "time_seed_to_harvest = @newSH, time_to_expire = @newEX WHERE crop_id = @cropId END " +
            "ELSE BEGIN INSERT INTO crops (crop_name, time_seed_to_transplant, time_transplant_to_harvest, time_seed_to_harvest, time_to_expire) " +
            "VALUES (@cropName, @newST, @newTH, @newSH, @newEX) END";
        private string sqlUpdateHarvestTime = "IF EXISTS (SELECT * FROM crops WHERE crop_name = @cropName) " +
            "BEGIN UPDATE crops SET time_seed_to_harvest = @newSH WHERE crop_name = @cropName END " +
            "ELSE BEGIN INSERT INTO crops (crop_name, time_seed_to_harvest) " +
            "VALUES (@cropName, @newSH) END";
        private string sqlUpdateExpirationTime = "IF EXISTS (SELECT * FROM crops WHERE crop_name = @cropName) " +
            "BEGIN UPDATE crops SET time_to_expire = @newEX WHERE crop_name = @cropName END " +
            "ELSE BEGIN INSERT INTO crops (crop_name, time_to_expire) " +
            "VALUES (@cropName, @newEX) END";
        private string sqlUpdateTransplantTime = "IF EXISTS (SELECT * FROM crops WHERE crop_name = @cropName) " +
            "BEGIN UPDATE crops SET time_seed_to_transplant = @newST, time_transplant_to_harvest = @newTH WHERE crop_name = @cropName END " +
            "ELSE BEGIN INSERT INTO crops (crop_name, time_seed_to_transplant, time_transplant_to_harvest) " +
            "VALUES (@cropName, @newST, @newTH) END";

        public CropSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Crop> GetAllCrops()
        {
            List<Crop> cropList = new List<Crop>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllCrops, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Crop currentCrop = new Crop();

                    currentCrop.cropId = Convert.ToInt32(reader["crop_id"]);
                    currentCrop.cropName = Convert.ToString(reader["crop_name"]);
                    currentCrop.timeSeedToTransplant = Convert.ToInt32(reader["time_seed_to_transplant"]);
                    currentCrop.timeTransplantToHarvest = Convert.ToInt32(reader["time_transplant_to_harvest"]);
                    currentCrop.timeSeedToHarvest = Convert.ToInt32(reader["time_seed_to_harvest"]);
                    currentCrop.timeToExpiration = Convert.ToInt32(reader["time_to_expire"]);

                    cropList.Add(currentCrop);
                }
            }

                return cropList;
        }

        public bool UpdateCrop(Crop someCrop)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateCrop, conn);
                    cmd.Parameters.AddWithValue("@cropId", someCrop.cropId);
                    cmd.Parameters.AddWithValue("@cropName", someCrop.cropName);
                    cmd.Parameters.AddWithValue("@newST", someCrop.timeSeedToTransplant);
                    cmd.Parameters.AddWithValue("@newTH", someCrop.timeTransplantToHarvest);
                    cmd.Parameters.AddWithValue("@newSH", someCrop.timeSeedToHarvest);
                    cmd.Parameters.AddWithValue("@newEX", someCrop.timeToExpiration);

                    cmd.ExecuteNonQuery();

                    result = true;

                }
            }

            catch(Exception e)
            {
                result = false;
            }

                return result;
        }

        public bool UpdateHarvestTime(Crop someCrop)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateHarvestTime, conn);
                    cmd.Parameters.AddWithValue("@cropName", someCrop.cropName);
                    cmd.Parameters.AddWithValue("@newSH", someCrop.timeSeedToHarvest);

                    int rowsReturned = cmd.ExecuteNonQuery();

                    if (rowsReturned > 0)
                    {
                        result = true;
                    }
                }
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public bool UpdateExpirationTime(Crop someCrop)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateExpirationTime, conn);
                    cmd.Parameters.AddWithValue("@cropName", someCrop.cropName);
                    cmd.Parameters.AddWithValue("@newEX", someCrop.timeToExpiration);

                    int rowsReturned = cmd.ExecuteNonQuery();

                    if (rowsReturned > 0)
                    {
                        result = true;
                    }
                }
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public bool UpdateTransplantTime(Crop someCrop)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateTransplantTime, conn);
                    cmd.Parameters.AddWithValue("@cropName", someCrop.cropName);
                    cmd.Parameters.AddWithValue("@newST", someCrop.timeSeedToTransplant);
                    cmd.Parameters.AddWithValue("@newTH", someCrop.timeTransplantToHarvest);

                    int rowsReturned = cmd.ExecuteNonQuery();

                    if (rowsReturned > 0)
                    {
                        result = true;
                    }
                }
            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

    }
}
