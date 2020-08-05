﻿using System;
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

        public UploadController (IUserDAO _userDAO)
        {
            userDAO = _userDAO;
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

        //[HttpPost("cropPlans")]
        //public IActionResult uploadCropPlans([FromBody] string value)
        //{
        //}
    }
}
