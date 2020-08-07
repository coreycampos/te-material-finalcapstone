using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class TransplantTime
    {
        public string crop { get; set; }

        public int direct_seed_to_transplant_time { get; set; }

        public int transplant_to_harvest_time { get; set; }
    }
}
