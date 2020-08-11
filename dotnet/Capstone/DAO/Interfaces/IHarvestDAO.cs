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

        bool AddNewHarvest(Harvest newHarvest);

        bool UpdateHarvest(Harvest someHarvest);


    }
}
