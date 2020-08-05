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
    [Authorize]
    public class UploadController : ControllerBase
    {
        private readonly IUserDAO userDAO;

        private readonly IPlanDAO planDAO;

        public UploadController (IUserDAO _userDAO)
        {
            userDAO = _userDAO;
        }

        public UploadController(IPlanDAO _planDAO)
        {
            planDAO = _planDAO;
        }

        [HttpPost("harvestTimes")]
        public void uploadHarvestTimes(List<HarvestTime> payload)
        {
            int fromUserId = 0;
            foreach (var claim in User.Claims)
            {
                if (claim.Type == "sub")
                {
                    fromUserId = int.Parse(claim.Value);
                }
            }
            Console.WriteLine(payload);
            Console.WriteLine(fromUserId);
            Console.WriteLine(Request.Body);

        }

        //[HttpPost("transplantTimes")]
        //public IActionResult uploadTransplantTimes([FromBody] string value)
        //{
        //}

        //[HttpPost("expirationTimes")]
        //public IActionResult uploadExpirationTimes([FromBody] string value)
        //{
        //}

        [HttpPost("cropPlans")]
        public IActionResult uploadCropPlans(List<CropPlan> cropPlans)
        {
            bool allUploaded = false;

            foreach (CropPlan newPlan in cropPlans)
            {
                bool result = planDAO.AddNewPlan(newPlan);

                if (!result)
                {
                    allUploaded = false;
                    return BadRequest();
                }
            }

            allUploaded = true;

            return Created("", allUploaded);
        }
    }
}
