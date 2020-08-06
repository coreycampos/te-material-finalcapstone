using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone.DAO
{
    public class LossSqlDAO: ILossDAO
    {
        private readonly string connectionString;
        private string sqlSelectAllLosses = "SELECT * FROM loss";
        private string sqlRecordNewLoss = "INSERT INTO loss (inventory_id, date_lost, amount_lost, loss_description) " +
            "VALUES (@inventoryId, @dateLost, @amountLost, @lossDescription);";

        public LossSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Loss> GetAllLosses()
        {
            List<Loss> lossList = new List<Loss>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlSelectAllLosses, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Loss currentLoss = new Loss();

                    currentLoss.lossId = Convert.ToInt32(reader["loss_id"]);
                    currentLoss.inventoryId = Convert.ToInt32(reader["inventory_id"]);
                    currentLoss.dateLost = Convert.ToDateTime(reader["date_lost"]);
                    currentLoss.amountLost = Convert.ToDecimal(reader["amount_lost"]);
                    currentLoss.lossDescription = Convert.ToString(reader["loss_description"]);

                    lossList.Add(currentLoss);
                }

                return lossList;
            }

        }

        public bool RecordNewLoss(Loss newLoss)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlRecordNewLoss, conn);
                    cmd.Parameters.AddWithValue("@inventoryId", newLoss.inventoryId);
                    cmd.Parameters.AddWithValue("@dateLost", newLoss.dateLost);
                    cmd.Parameters.AddWithValue("@amountLost", newLoss.amountLost);
                    cmd.Parameters.AddWithValue("@lossDescription", newLoss.lossDescription);

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
