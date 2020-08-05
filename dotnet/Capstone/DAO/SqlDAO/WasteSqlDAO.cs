using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO.SqlDAO
{
    public class WasteSqlDAO : IWasteDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllWastes = "SELECT * FROM waste";

        public WasteSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Waste> GetAllWastes()
        {
            List<Waste> wasteList = new List<Waste>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllWastes, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Waste currentWaste = new Waste();

                    currentWaste.wasteId = Convert.ToInt32(reader["loss_id"]);
                    currentWaste.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentWaste.dateWasted = Convert.ToDateTime(reader["date_wasted"]);
                    currentWaste.amountWasted = Convert.ToDecimal(reader["amount_wasted"]);
                    currentWaste.wasteDescription = Convert.ToString(reader["waste_description"]);

                    wasteList.Add(currentWaste);
                }

                return wasteList;
            }

        }
    }
}
