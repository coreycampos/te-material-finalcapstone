using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IInventoryDAO
    {
        List<Inventory> GenericSelectInventory(string someSqlCommand);

        List<Inventory> GetAllInventory();

        decimal GetTotalItem(string cropName);

        bool AddInventory(Inventory newInventory);

        bool debitInventory(int inventoryId, decimal debit);


    }
}
