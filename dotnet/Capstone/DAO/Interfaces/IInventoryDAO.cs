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

        //Get all inventory items

        List<Inventory> GetAllInventory();

        //What's expiring within 7 days?

        List<Inventory> ExpiringWithinWeek();

    }
}
