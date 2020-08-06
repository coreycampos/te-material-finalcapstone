using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class TransplantTime
    {
        public string crop { get; set; }

        public int time_seed_to_transplant { get; set; }

        public int time_transplant_to_harvest { get; set; }
    }
}
