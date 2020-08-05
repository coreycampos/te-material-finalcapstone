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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryDAO inventoryDAO;

        public InventoryController(IInventoryDAO _inventoryDAO)
        {
            inventoryDAO = _inventoryDAO;
        }

        [HttpGet("allInventory")]
        public List<Inventory> getAllInventory()
        {
            List<Inventory> inventoryList = inventoryDAO.GetAllInventory();
            return inventoryList;
        }

    }
}
