using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class PlanSqlDAO : IPlanDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllPlans = "SELECT plan_id, crop_plans.crop_id , crops.crop_name, area_identifier, planting_date FROM crop_plans INNER JOIN crops ON crops.crop_id=crop_plans.crop_id;";
        private string sqlPlansWithinWeek = "SELECT * FROM crop_plans WHERE planting_date < DATEADD(day, 7, GETDATE());";
        private string sqlAddNewPlan = "INSERT INTO crop_plans (crop_id, area_identifier, planting_date) VALUES (@cropId, @area, @plantingDate)";
        private string sqlUpdatePlan = "UPDATE crop_plans SET crop_id = @cropId, area_identifier = @area, planting_date = @plantingDate WHERE plan_id = @planId;";
        private string sqlGetCropId = "SELECT crop_id FROM crops WHERE crop_name = @cropName;";
        private string sqlGetCropName = "SELECT crop_name from crops WHERE crop_id = @cropId;";

        public PlanSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<CropPlan> GenericSelectPlans(string someSqlCommand)
        {
            List<CropPlan> planList = new List<CropPlan>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(someSqlCommand, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read() == true)
                {
                    CropPlan currentPlan = new CropPlan();

                    currentPlan.planId = Convert.ToInt32(reader["plan_id"]);
                    currentPlan.cropId = Convert.ToInt32(reader["crop_id"]);
                    currentPlan.crop = Convert.ToString(reader["crop_name"]);
                    currentPlan.area_identifier = Convert.ToString(reader["area_identifier"]);
                    currentPlan.planting_date = Convert.ToString(reader["planting_date"]);

                    planList.Add(currentPlan);
                }
                //reader.Close();
                //SqlCommand gettingCropName = new SqlCommand(sqlGetCropName, conn);
                //gettingCropName.Parameters.AddWithValue("@cropId", currentPlan.cropId);
                //currentPlan.cropName = (string)gettingCropName.ExecuteScalar();

                return planList;
            }
        }

        public List<CropPlan> GetAllPlans()
        {
            return GenericSelectPlans(sqlSelectAllPlans);
        }

        public List<CropPlan> PlansWithinWeek()
        {
            return GenericSelectPlans(sqlPlansWithinWeek);
        }

        public bool AddNewPlan(CropPlan newPlan)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // query to select the cropId from our crop name, execute scalar to give first value
                    SqlCommand gettingCropId = new SqlCommand(sqlGetCropId, conn);
                    gettingCropId.Parameters.AddWithValue("@cropName", newPlan.crop);
                    object cropId = gettingCropId.ExecuteScalar();
                    // This is where I would add validation for if the crop is already in the DB
                    // If the cropId object comes back as 'null', it is not in DB yet,
                    // return message to user saying that that specific crop has not been uploaded yet
                                       
                    SqlCommand cmd = new SqlCommand(sqlAddNewPlan, conn);
                    cmd.Parameters.AddWithValue("@cropId", cropId);
                    cmd.Parameters.AddWithValue("@area", newPlan.area_identifier);
                    cmd.Parameters.AddWithValue("@plantingDate", newPlan.planting_date);
                    int rowsReturned = cmd.ExecuteNonQuery();
                    if (rowsReturned > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                result = false;
            }
            return result;
        }

        public bool UpdatePlan(CropPlan somePlan)
        {
            bool result = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand gettingCropId = new SqlCommand(sqlGetCropId, conn);
                    gettingCropId.Parameters.AddWithValue("@cropName", somePlan.crop);
                    object cropId = gettingCropId.ExecuteScalar();

                    SqlCommand cmd = new SqlCommand(sqlUpdatePlan, conn);
                    cmd.Parameters.AddWithValue("@planId", somePlan.planId);
                    cmd.Parameters.AddWithValue("@cropId", cropId);
                    cmd.Parameters.AddWithValue("@area", somePlan.area_identifier);
                    cmd.Parameters.AddWithValue("@plantingDate", somePlan.planting_date);
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
    }
}
