using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class CropPlan
    {
        public int planId { get; set; }

        public int cropId { get; set; }

        public string area { get; set; }

        public DateTime plantingDate { get; set; }
    }
}
