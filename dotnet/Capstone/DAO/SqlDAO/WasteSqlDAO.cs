﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class WasteSqlDAO : IWasteDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllWastes = "SELECT * FROM waste";
        private string sqlRecordNewWaste = "INSERT INTO waste (inventory_id, date_wasted, amount_wasted, waste_description) " +
            "VALUES (@inventoryId, @dateWasted, @amountWasted, @wasteDescription);";

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

                    currentWaste.wasteId = Convert.ToInt32(reader["waste_id"]);
                    currentWaste.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentWaste.dateWasted = Convert.ToDateTime(reader["date_wasted"]);
                    currentWaste.amountWasted = Convert.ToDecimal(reader["amount_wasted"]);
                    currentWaste.wasteDescription = Convert.ToString(reader["waste_description"]);

                    wasteList.Add(currentWaste);
                }

                return wasteList;
            }

        }

        public bool RecordNewWaste(Waste newWaste)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlRecordNewWaste, conn);
                    cmd.Parameters.AddWithValue("@inventoryId", newWaste.inventoryId);
                    cmd.Parameters.AddWithValue("@dateWasted", newWaste.dateWasted);
                    cmd.Parameters.AddWithValue("@amountWasted", newWaste.amountWasted);
                    cmd.Parameters.AddWithValue("@wasteDescription", newWaste.wasteDescription);

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
