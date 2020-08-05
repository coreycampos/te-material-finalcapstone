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
        private readonly ICropDAO cropDAO;

        public UploadController (IUserDAO _userDAO, ICropDAO _cropDAO)
        {
            userDAO = _userDAO;
            cropDAO = _cropDAO;
        }

        [HttpPost("harvestTimes")]
        public void UploadHarvestTimes(List<HarvestTime> payload)
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
        //public IActionResult UploadTransplantTimes(List<TransplantTime> payload)
        //{
        //}

        //[HttpPost("expirationTimes")]
        //public IActionResult UploadExpirationTimes(List<ExpirationTime> payload)
        //{
        //}

        //[HttpPost("cropPlans")]
        //public IActionResult UploadCropPlans(CropPlans payload)
        //{
        //}

        [HttpPut("cropUpdate")]
        public IActionResult UpdateCrop(Crop updatedCrop)
        {
            Console.WriteLine(updatedCrop);

            int shouldBeOne = cropDAO.UpdateCrop(updatedCrop);
            if (shouldBeOne == 1)
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
