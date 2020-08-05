using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class SalesSqlDAO : ISaleDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllSales = "SELECT * FROM sales";

        public SalesSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Sales> GetAllSales()
        {
            List<Sales> salesList = new List<Sales>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllSales, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Sales currentSale = new Sales();

                    currentSale.saleId = Convert.ToInt32(reader["sale_id"]);
                    currentSale.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentSale.dateSold = Convert.ToDateTime(reader["date_sold"]);
                    currentSale.amountSold = Convert.ToDecimal(reader["amount_sold"]);
                    currentSale.methodOfSale = Convert.ToString(reader["method_of_sale"]);

                    salesList.Add(currentSale);
                }

                return salesList;
            }

        }
    }
}
