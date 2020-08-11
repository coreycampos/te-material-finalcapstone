using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Loss
    {
        public int lossId { get; set; }

        public int inventoryId { get; set; }

        public string cropName { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime dateLost { get; set; }

        public Decimal amountLost { get; set; }

        public string lossDescription { get; set; }
    }
}
