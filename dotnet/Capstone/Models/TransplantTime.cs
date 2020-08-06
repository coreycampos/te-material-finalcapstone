using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class TransplantTime
    {
        public string crop { get; set; }

        public int timeSeedToTransplant { get; set; }

        public int timeTransplantToHarvest { get; set; }
    }
}
