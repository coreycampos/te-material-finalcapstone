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

    public class PlanController : ControllerBase
    {
        public IPlanDAO planDAO;

        public PlanController(IPlanDAO _planDAO)
        {
            planDAO = _planDAO;
        }

        [HttpGet("allPlans")]
        public List<CropPlan> GetAllPlans()
        {
            List<CropPlan> planList = planDAO.GetAllPlans();
            return planList;
        }
    }
}
