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
    public class HarvestController : ControllerBase
    {
        private readonly IHarvestDAO harvestDAO;
        private readonly IInventoryDAO inventoryDAO;

        public HarvestController(IHarvestDAO _harvestDAO, IInventoryDAO _inventoryDAO)
        {
            harvestDAO = _harvestDAO;
            inventoryDAO = _inventoryDAO;
        }

        [HttpGet("allHarvests")]
        public List<Harvest> GetAllHarvests()
        {
            List<Harvest> harvestList = harvestDAO.GetAllHarvests();
            return harvestList;
        }

        [HttpPost("newHarvest")]
        public IActionResult AddNewHarvest(Harvest newHarvest)
        {
            bool result = false;
            bool inventoryResult = inventoryDAO.AddInventory(newHarvest.cropID, newHarvest.weight, newHarvest.dateHarvested);
            if (inventoryResult)
            {
                result = harvestDAO.AddNewHarvest(newHarvest);
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
        [HttpPut("updateHarvest")]
        public IActionResult UpdatePlan(Harvest someHarvest)
        {
            bool result = harvestDAO.UpdateHarvest(someHarvest);

            if (result)
            {
                return Ok("Update successful");
            }
            else
            {
                return BadRequest("Update failed");
            }
        }

    }
}
