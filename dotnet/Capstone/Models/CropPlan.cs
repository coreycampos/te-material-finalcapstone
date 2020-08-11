using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class CropPlan
    {
        public int planId { get; set; }

        public string area_identifier { get; set; }

        public string crop { get; set; }

        public int cropId { get; set; }

        public string planting_date { get; set; }
    }
}
