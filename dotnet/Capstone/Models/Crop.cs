using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Crop
    {
        public int cropId { get; set; }

        public string cropName { get; set; }

        public int timeSeedToTransplant { get; set; }

        public int timeTransplantToHarvest { get; set; }

        public int timeSeedToHarvest { get; set; }

        public int timeToExpiration { get; set; }

    }
}
