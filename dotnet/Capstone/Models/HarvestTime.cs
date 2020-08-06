using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class HarvestTime
    {
        public string crop { get; set; }

        //[JsonProperty(PropertyName = "rotation_period")]
        public int time_to_harvest { get; set; }
    }
}
