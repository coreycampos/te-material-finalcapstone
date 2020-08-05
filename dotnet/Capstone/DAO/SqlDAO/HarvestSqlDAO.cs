using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO.SqlDAO
{
    public class HarvestSqlDAO : IHarvestDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllHarvests = "SELECT * FROM harvests";

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
                    currentHarvest.area = Convert.ToString(reader["area_identifier"]);
                    currentHarvest.weight = Convert.ToDecimal(reader["weight_count"]);
                    currentHarvest.dateHarvested = Convert.ToDateTime(reader["date_harvested"]);

                    harvestList.Add(currentHarvest);
                }

                return harvestList;
            }
        }
    }
}
