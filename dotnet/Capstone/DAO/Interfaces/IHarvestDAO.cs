using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IHarvestDAO
    {
        List<Harvest> GenericSelectHarvest(string sqlCommand);

        List<Harvest> GetAllHarvests();

        Harvest GetSpecificHarvest(int harvestId);

        bool AddNewHarvest(Harvest newHarvest, int inventoryId);

        bool UpdateHarvest(Harvest someHarvest);

        int GetCropId(string cropName);
    }
}
