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
    public class LossController : ControllerBase
    {
        private readonly ILossDAO lossDAO;

        public LossController(ILossDAO _lossDAO)
        {
            lossDAO = _lossDAO;
        }

        [HttpGet("allLoss")]
        public List<Loss> GetAllLosses()
        {
            List<Loss> lossList = lossDAO.GetAllLosses();
            return lossList;
        }
        [HttpPost("newLoss")]
        public IActionResult AddNewLoss(Loss newLoss)
        {
            bool result = lossDAO.RecordNewLoss(newLoss);

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
