using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Inventory
    {
        public int inventoryId { get; set; }

        public int cropId { get; set; }

        public string cropName { get; set; }

        public Decimal amount { get; set; }

        public DateTime dateAdded { get; set; }

    }
}
