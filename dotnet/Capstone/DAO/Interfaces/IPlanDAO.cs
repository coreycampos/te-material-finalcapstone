using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface IPlanDAO
    {
        List<CropPlan> GenericSelectPlans(string someSqlCommand);

        // Get all planned harvests

        List<CropPlan> GetAllPlans();

        // What must be harvested within the next 7 days?

        List<CropPlan> PlansWithinWeek();

        // Add a new plan

        bool AddNewPlan(CropPlan newPlan);

        //Update a plan

        bool UpdatePlan(CropPlan somePlan);
    }
}
