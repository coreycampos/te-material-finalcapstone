using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Waste
    {
        public int wasteId { get; set; }

        public int inventoryId { get; set; }

        public string cropName { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime dateWasted { get; set; }

        public Decimal amountWasted { get; set; }

        public string wasteDescription { get; set; }
    }
}
