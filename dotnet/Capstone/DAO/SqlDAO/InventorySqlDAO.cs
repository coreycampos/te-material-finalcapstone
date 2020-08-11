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
        private string sqlAddInventory = "INSERT INTO inventory (crop_id, amount, date_added) VALUES (@cropId, @amount, @dateAdded)";
        private string sqlDebitInventory = "UPDATE inventory SET amount = amount - @debit WHERE inventory_id = @inventoryId";
        private string sqlGetItemTotal = "SELECT SUM(amount) AS total FROM inventory WHERE crop_name = @cropName";

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
                    currentInventory.cropId = Convert.ToInt32(reader["crop_id"]);
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

        public decimal GetTotalItem(string cropName)
        {
            decimal totalOnHand = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetItemTotal, conn);
                cmd.Parameters.AddWithValue("@cropName", cropName);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    totalOnHand = Convert.ToDecimal(reader["total"]);
                }

                return totalOnHand;
            }
        }

        public bool AddInventory(int cropId, decimal amount, DateTime dateAdded)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddInventory, conn);
                    cmd.Parameters.AddWithValue("@cropId", cropId);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@dateAdded", dateAdded);

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

        public bool debitInventory(int inventoryId, decimal debit)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlDebitInventory, conn);
                    cmd.Parameters.AddWithValue("@inventoryId", inventoryId);
                    cmd.Parameters.AddWithValue("@debit", debit);

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
