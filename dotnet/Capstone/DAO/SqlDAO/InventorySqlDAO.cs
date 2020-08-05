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
        private string sqlExpiringWithinWeek = "SELECT * FROM inventory AS i JOIN harvests AS h ON h.harvest_id = i.harvest_id "
+ "JOIN crops AS c ON h.crop_id = c.crop_id WHERE DATEDIFF(day, DATEADD(day, c.time_to_expire, i.date_added), GETDATE()) <= 7;";

        public InventorySqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Inventory> GenericSelectInventory(string someSqlCommand)
        {
            List<Inventory> inventoryList = new List<Inventory>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(someSqlCommand, conn);
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
        public List<Inventory> GetAllInventory()
        {
            return GenericSelectInventory(sqlSelectAllInventory);
        }

        public List<Inventory> ExpiringWithinWeek()
        {
            return GenericSelectInventory(sqlExpiringWithinWeek);
        }
    }
}
