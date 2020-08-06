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
        public IActionResult UploadHarvestTimes(List<HarvestTime> payload)
        {
            Console.WriteLine(payload);
            Console.WriteLine(Request.Body);

            bool allUploaded = false;

            foreach (HarvestTime newCropData in payload)
            {
                Crop updatedCrop = new Crop();
                updatedCrop.cropName = newCropData.crop;
                updatedCrop.timeSeedToHarvest = newCropData.time_to_harvest;

                bool result = cropDAO.UpdateCrop(updatedCrop);

                if (!result)
                {
                    allUploaded = false;
                    return BadRequest();
                }
            }
            allUploaded = true;
            return Created("", allUploaded);
        }

        [HttpPut("transplantTimes")]
        public IActionResult UploadTransplantTimes(List<TransplantTime> payload)
        {
            Console.WriteLine(payload);
            Console.WriteLine(Request.Body);

            bool allUploaded = false;

            foreach (TransplantTime newCropData in payload)
            {
                Crop updatedCrop = new Crop();
                updatedCrop.cropName = newCropData.crop;
                updatedCrop.timeSeedToTransplant = newCropData.time_seed_to_transplant;
                updatedCrop.timeTransplantToHarvest = newCropData.time_transplant_to_harvest;

                bool result = cropDAO.UpdateCrop(updatedCrop);

                if (!result)
                {
                    allUploaded = false;
                    return BadRequest();
                }
            }

            allUploaded = true;

            return Created("", allUploaded);
        }

        [HttpPost("expirationTimes")]
        public IActionResult UploadExpirationTimes(List<ExpirationTime> payload)
        {
            Console.WriteLine(payload);
            Console.WriteLine(Request.Body);

            bool allUploaded = false;

            foreach (ExpirationTime newCropData in payload)
            {
                Crop updatedCrop = new Crop();
                updatedCrop.cropName = newCropData.crop;
                updatedCrop.timeSeedToHarvest = newCropData.time_to_expiration;

                bool result = cropDAO.UpdateCrop(updatedCrop);

                if (!result)
                {
                    allUploaded = false;
                    return BadRequest();
                }
            }
            allUploaded = true;
            return Created("", allUploaded);
        }

        [HttpPut("cropPlans")]
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

        [HttpPut("cropUpdate")]
        public IActionResult UpdateCrop(Crop someCrop)
        {

            bool result = cropDAO.UpdateCrop(someCrop);

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
