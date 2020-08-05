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
    public class CropController : ControllerBase
    {
        private readonly ICropDAO cropDAO;

        public CropController(ICropDAO _cropDAO)
        {
            cropDAO = _cropDAO;
        }

        [HttpGet("allCrops")]
        public List<Crop> getAllCrops()
        {
            List<Crop> cropList = cropDAO.GetAllCrops();
            return cropList;
        }

    }
}
