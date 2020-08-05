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

        public SalesController(ISaleDAO _salesDAO)
        {
            salesDAO = _salesDAO;
        }

        [HttpGet("allSales")]
        public List<Sales> GetAllSales()
        {
            List<Sales> salesList = salesDAO.GetAllSales();
            return salesList;
        }

    }
}
