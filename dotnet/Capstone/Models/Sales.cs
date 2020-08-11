using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Sales
    {
        public int saleId { get; set; }

        public int inventoryId { get; set; }

        public string cropName { get; set; }

        public DateTime dateAdded { get; set; }

        public DateTime dateSold { get; set; }

        public Decimal amountSold { get; set; }

        public Decimal revenue { get; set; }

        public string methodOfSale { get; set; }
        

    }
}
