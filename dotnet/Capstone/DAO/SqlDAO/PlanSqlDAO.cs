using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO.SqlDAO
{
    public class PlanSqlDAO : IPlanDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllPlans = "SELECT * FROM crop_plans";

        public PlanSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<CropPlan> GetAllPlans()
        {
            List<CropPlan> planList = new List<CropPlan>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllPlans, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    CropPlan currentPlan = new CropPlan();

                    currentPlan.planId = Convert.ToInt32(reader["plan_id"]);
                    currentPlan.cropId = Convert.ToInt32(reader["crop_id"]);
                    currentPlan.area = Convert.ToString(reader["area_identifier"]);
                    currentPlan.plannedDateOfHarvest = Convert.ToDateTime(reader["planned_harvest_date"]);

                    planList.Add(currentPlan);
                }

                return planList;
            }

        }
    }
}
