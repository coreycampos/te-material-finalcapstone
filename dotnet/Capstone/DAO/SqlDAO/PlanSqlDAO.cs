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
        private string sqlSelectAllPlans = "SELECT * FROM crop_plans";
        private string sqlPlansWithinWeek = "SELECT * FROM crop_plans WHERE planting_date < DATEADD(day, 7, GETDATE());";
        private string sqlAddNewPlan = "INSERT INTO crop_plans (crop_id, area_identifier, planting_date) VALUES (@cropId, @area, @plantingDate)";
        private string sqlUpdatePlan = "UPDATE crop_plans SET crop_id = @cropId, area_identifier = @area, planting_date = @plantingDate WHERE plan_id = @planId;";

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
                    currentPlan.crop = Convert.ToString(reader["crop_id"]);
                    currentPlan.area_identifier = Convert.ToString(reader["area_identifier"]);
                    currentPlan.planting_date = Convert.ToInt32(reader["planting_date"]);

                    planList.Add(currentPlan);
                }

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

                    SqlCommand cmd = new SqlCommand(sqlAddNewPlan, conn);
                    cmd.Parameters.AddWithValue("@cropId", newPlan.crop);
                    cmd.Parameters.AddWithValue("@area", newPlan.area_identifier);
                    cmd.Parameters.AddWithValue("@plantingDate", newPlan.planting_date);
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

        public bool UpdatePlan(CropPlan somePlan)
        {
            bool result = false;

            try
            {

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddNewPlan, conn);
                    cmd.Parameters.AddWithValue("@planId", somePlan.planId);
                    cmd.Parameters.AddWithValue("@cropId", somePlan.crop);
                    cmd.Parameters.AddWithValue("@area", somePlan.area_identifier);
                    cmd.Parameters.AddWithValue("@plantingDate", somePlan.planting_date);
                    cmd.ExecuteNonQuery();

                }

                result = true;

            }

            catch (Exception e)
            {
                result = false;
            }

            return result;
        }
    }
}
