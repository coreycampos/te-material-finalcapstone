using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IWasteDAO
    {
        List<Waste> GetAllWastes();
        bool RecordNewWaste(Waste newWaste);
    }
}
