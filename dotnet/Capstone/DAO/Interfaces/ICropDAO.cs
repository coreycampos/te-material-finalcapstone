using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ICropDAO
    {
        List<Crop> GetAllCrops();

        bool UpdateCrop(string cropName, string updatedAttribute, int newValue);
    }
}
