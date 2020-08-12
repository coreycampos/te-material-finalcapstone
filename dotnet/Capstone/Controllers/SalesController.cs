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
    public class SalesController : ControllerBase
    {
        private readonly ISaleDAO salesDAO;
        private readonly IInventoryDAO inventoryDAO;

        public SalesController(ISaleDAO _salesDAO, IInventoryDAO _inventoryDAO)
        {
            salesDAO = _salesDAO;
            inventoryDAO = _inventoryDAO;
        }

        [HttpGet("allSales")]
        public List<Sales> GetAllSales()
        {
            List<Sales> salesList = salesDAO.GetAllSales();
            return salesList;
        }
        [HttpPost("newSale")]
        public IActionResult AddNewSale(Sales newSale)
        {
            bool result = false;
            bool inventoryResult = inventoryDAO.DebitInventory(newSale.inventoryId, newSale.amountSold);
            if (inventoryResult)
            {
                result = salesDAO.RecordNewSale(newSale);
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
