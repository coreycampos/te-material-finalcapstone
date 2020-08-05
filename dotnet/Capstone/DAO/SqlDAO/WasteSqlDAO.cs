using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.SqlDAO
{
    public class WasteSqlDAO : IWasteDAO
    {
        public List<Waste> GetAllWastes()
        {
            List<Waste> wasteList = new List<Waste>();

            return wasteList;
        }
    }
}
