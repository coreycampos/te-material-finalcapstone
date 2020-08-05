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
        private string sqlUpdateCrop = "UPDATE crops SET @attribute = @newValue WHERE crop_name = @cropName";

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
                    currentCrop.timeSeedToTransplant = Convert.ToInt32(reader["time_seed_to_harvest"]);
                    currentCrop.timeToExpiration = Convert.ToInt32(reader["time_to_expire"]);

                    cropList.Add(currentCrop);
                }
            }

                return cropList;
        }

        public bool AddCrop(Crop newCrop)
        {
            bool result = false;

            return result;

        }

        public bool UpdateCrop(string cropName, string updatedAttribute, int newValue)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlUpdateCrop, conn);
                    cmd.Parameters.AddWithValue("@attribute", updatedAttribute);
                    cmd.Parameters.AddWithValue("@newValue", newValue);
                    cmd.Parameters.AddWithValue("@cropName", cropName);

                    cmd.ExecuteNonQuery();

                    result = true;

                }
            }

            catch
            {
                result = false;
            }



                return result;
        }

    }
}
