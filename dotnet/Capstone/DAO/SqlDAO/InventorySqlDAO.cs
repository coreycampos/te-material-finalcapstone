using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class InventorySqlDAO : IInventoryDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllInventory = "SELECT * FROM inventory";

        public InventorySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Inventory> GetAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllInventory, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Inventory currentInventory = new Inventory();

                    currentInventory.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentInventory.harvestId = Convert.ToInt32(reader["harvest_id"]);
                    currentInventory.amount = Convert.ToDecimal(reader["amount"]);
                    currentInventory.dateAdded = Convert.ToDateTime(reader["date_added"]);

                    inventoryList.Add(currentInventory);
                }

                return inventoryList;
            }

        }
    }
}
