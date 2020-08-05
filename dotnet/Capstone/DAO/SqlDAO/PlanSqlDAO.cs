using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO.SqlDAO
{
    public class PlanSqlDAO : IPlanDAO
    {
        public List<CropPlan> GetAllPlans()
        {
            List<CropPlan> planList = new List<CropPlan>();

            return planList;
        }
    }
}
