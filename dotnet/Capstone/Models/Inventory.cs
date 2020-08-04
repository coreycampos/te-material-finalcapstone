using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Inventory
    {
        public int inventoryId { get; set; }

        public int harvestId { get; set; }

        public int amount { get; set; }

        public DateTime dateAdded { get; set; }
    }
}
