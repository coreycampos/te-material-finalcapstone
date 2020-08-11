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

        Inventory GetSpecificInventory(int inventoryId);

        bool AddInventory(int cropId, decimal amount, DateTime dateAdded);

        bool debitInventory(int inventoryId, decimal debit);


    }
}
