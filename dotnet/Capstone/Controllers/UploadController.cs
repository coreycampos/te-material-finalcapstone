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
        private readonly IPlanDAO planDAO;

        public UploadController (IUserDAO _userDAO, ICropDAO _cropDAO, IPlanDAO _planDAO)
        {
            userDAO = _userDAO;
            cropDAO = _cropDAO;
            planDAO = _planDAO;
        }

        [HttpPut("harvestTimes")]
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

        //[HttpPut("transplantTimes")]
        //public IActionResult UploadTransplantTimes(List<TransplantTime> payload)
        //{
        //    Console.WriteLine(payload);
        //    Console.WriteLine(Request.Body);

        //    bool allUploaded = false;

        //    foreach (TransplantTime newCropData in payload)
        //    {
        //        bool result1 = cropDAO.UpdateCrop(newCropData.crop, "timeSeedToTransplant", newCropData.timeSeedToTransplant);
        //        bool result2 = cropDAO.UpdateCrop(newCropData.crop, "timeTransplantToHarvest", newCropData.timeTransplantToHarvest);

        //        if (!result1 || !result2)
        //        {
        //            allUploaded = false;
        //            return BadRequest();
        //        }
        //    }

        //    allUploaded = true;

        //    return Created("", allUploaded);
        //}

    //    [HttpPost("expirationTimes")]
    //    public IActionResult UploadExpirationTimes(List<ExpirationTime> payload)
    //    {
    //        Console.WriteLine(payload);
    //        Console.WriteLine(Request.Body);

    //        bool result = cropDAO.UpdateCrop(newCropData.crop, "timeSeedToTransplant", newCropData.timeSeedToTransplant);

    //        if (!result)
    //        {
    //            allUploaded = false;
    //            return BadRequest();
    //        }
    //    }

    //    allUploaded = true;

    //        return Created("", allUploaded);
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
        //[HttpPost("cropPlans")]
        //public IActionResult UploadCropPlans(CropPlans payload)
        //{
        //}

        [HttpPut("cropUpdate")]
        public IActionResult UpdateCrop(string cropName, string updatedAttribute, int newValue)
        {
            Console.WriteLine(cropName);
            Console.WriteLine(updatedAttribute);
            Console.WriteLine(newValue);

            bool result = cropDAO.UpdateCrop(cropName, updatedAttribute, newValue);

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
