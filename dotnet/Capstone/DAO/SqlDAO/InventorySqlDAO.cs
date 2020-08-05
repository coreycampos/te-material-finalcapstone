using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.SqlDAO
{
    public class InventorySqlDAO : IInventoryDAO
    {
       public List<Inventory> GetAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();

            return inventoryList;
        }
    }
}
