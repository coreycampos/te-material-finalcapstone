using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WasteController : ControllerBase
    {
        private readonly IWasteDAO wasteDAO;

        public WasteController(IWasteDAO _wasteDAO)
        {
            wasteDAO = _wasteDAO;
        }

        [HttpGet("allLoss")]
        public List<Waste> GetAllWaste()
        {
            List<Waste> wasteList = wasteDAO.GetAllWastes();
            return wasteList;
        }

    }
}
