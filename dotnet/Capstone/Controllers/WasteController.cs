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
        private readonly IInventoryDAO inventoryDAO;

        public WasteController(IWasteDAO _wasteDAO, IInventoryDAO _inventoryDAO)
        {
            wasteDAO = _wasteDAO;
            inventoryDAO = _inventoryDAO;
        }

        [HttpGet("allWaste")]
        public List<Waste> GetAllWaste()
        {
            List<Waste> wasteList = wasteDAO.GetAllWastes();
            return wasteList;
        }
        [HttpPost("newWaste")]
        public IActionResult AddNewWaste(Waste newWaste)
        {
            bool result = false;
            bool inventoryResult = inventoryDAO.DebitInventory(newWaste.inventoryId, newWaste.amountWasted);
            if (inventoryResult)
            {
                result = wasteDAO.RecordNewWaste(newWaste);
            }
            if (result)
            {
                return Created("", result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
