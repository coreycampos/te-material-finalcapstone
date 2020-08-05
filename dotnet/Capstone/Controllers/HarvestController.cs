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

        public HarvestController(IHarvestDAO _harvestDAO)
        {
            harvestDAO = _harvestDAO;
        }

        [HttpGet("allHarvests")]
        public List<Harvest> GetAllHarvests()
        {
            List<Harvest> harvestList = harvestDAO.GetAllHarvests();
            return harvestList;
        }

    }
}
