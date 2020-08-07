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

        bool UpdateCrop(Crop someCrop);

        bool UpdateHarvestTime(Crop someCrop);

        bool UpdateExpirationTime(Crop someCrop);

        bool UpdateTransplantTime(Crop someCrop);
    }
}
