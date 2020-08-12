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
        private string sqlSelectAllInventory = "SELECT c.crop_name, i.* FROM inventory AS i JOIN crops AS c ON i.crop_id = c.crop_id;";
        private string sqlAddInventory = "INSERT INTO inventory (crop_id, amount, date_added) VALUES (@cropId, @amount, @dateAdded);";
        private string sqlDebitInventory = "UPDATE inventory SET amount = amount - @debit WHERE inventory_id = @inventoryId;";
        private string sqlGetSpecificInventory = "SELECT inventory_id, crops.crop_name, inventory.crop_id, amount, date_added FROM inventory JOIN crops on crops.crop_id = inventory.crop_id WHERE inventory_id = @inventoryId;";
        private string sqlGetMostRecentInventoryId = "SELECT TOP 1 inventory_id FROM inventory ORDER BY inventory_id DESC;";

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

                    currentInventory.cropName = Convert.ToString(reader["crop_name"]);
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

        public Inventory GetSpecificInventory(int inventoryId)
        {
            Inventory currentInventory = new Inventory();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlGetSpecificInventory, conn);
                cmd.Parameters.AddWithValue("@inventoryId", inventoryId);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    currentInventory.cropName = Convert.ToString(reader["crop_name"]);
                    currentInventory.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentInventory.cropId = Convert.ToInt32(reader["crop_id"]);
                    currentInventory.amount = Convert.ToDecimal(reader["amount"]);
                    currentInventory.dateAdded = Convert.ToDateTime(reader["date_added"]);
                }

                return currentInventory;
            }
        }

        public int AddInventory(int cropId, decimal amount, DateTime dateAdded)
        {
            int currentInventoryId = 0;

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

                    SqlCommand cmdGetInventoryId = new SqlCommand(sqlGetMostRecentInventoryId, conn);
                    currentInventoryId = (int)cmdGetInventoryId.ExecuteScalar();

                    return currentInventoryId;
                }
            }
            catch
            {
                currentInventoryId = 0;

                return currentInventoryId;
            }
        }

        public bool DebitInventory(int inventoryId, decimal debit)
        {
            bool result = false;

            try
            {
                Inventory currentInventory = GetSpecificInventory(inventoryId);

                if (debit > currentInventory.amount)
                {
                    return result;
                }

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
