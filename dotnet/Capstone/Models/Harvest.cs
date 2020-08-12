using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Harvest
    {
        public int harvestId { get; set; }

        public int cropID { get; set; }

        public string cropName { get; set; }

        public string area { get; set; }

        public Decimal weight { get; set; }

        public DateTime dateHarvested { get; set; }

        public int inventoryId { get; set; }

    }
}
