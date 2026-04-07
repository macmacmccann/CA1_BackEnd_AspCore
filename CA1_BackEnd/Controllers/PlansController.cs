using CA1_BackEnd.Data;
using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private static List<Plan> plans => DataStore.Plans;
        private static List<Meal> meals => DataStore.Meals;

        [HttpGet]
        public ActionResult<IEnumerable<Plan>> GetAllPlans()
        {
            return Ok(plans);
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> GetPlanById(int id)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        [HttpGet("{id}/meals")]
        public ActionResult<IEnumerable<Meal>> GetMealsByPlan(int id)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            var planMeals = meals.Where(m => m.PlanId == id);
            return Ok(planMeals);
        }

        [HttpPost]
        public ActionResult<Plan> CreatePlan([FromBody] Plan plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            plans.Add(plan);
            return CreatedAtAction(nameof(GetPlanById), new { id = plan.Id }, plan);
        }

        [HttpPut("{id}")]
        public ActionResult<Plan> UpdatePlan(int id, [FromBody] Plan updatedPlan)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            plan.Name = updatedPlan.Name;
            plan.Description = updatedPlan.Description;

            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlan(int id)
        {
            var plan = plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

         
            foreach (var meal in meals.Where(m => m.PlanId == id))
                meal.PlanId = null;

            plans.Remove(plan);
            return Ok(plan);
        }

        // POST /api/plans/{planId}/meals/{mealId} — assign a meal to a plan
        [HttpPost("{planId}/meals/{mealId}")]
        public ActionResult AssignMealToPlan(int planId, int mealId)
        {
            var plan = plans.FirstOrDefault(p => p.Id == planId);
            if (plan == null)
                return NotFound($"Plan {planId} not found.");

            var meal = meals.FirstOrDefault(m => m.Id == mealId);
            if (meal == null)
                return NotFound($"Meal {mealId} not found.");

            meal.PlanId = planId;
            return Ok(meal);
        }

        // DELETE /api/plans/{planId}/meals/{mealId} — remove a meal from a plan
        [HttpDelete("{planId}/meals/{mealId}")]
        public ActionResult RemoveMealFromPlan(int planId, int mealId)
        {
            var plan = plans.FirstOrDefault(p => p.Id == planId);
            if (plan == null)
                return NotFound($"Plan {planId} not found.");

            var meal = meals.FirstOrDefault(m => m.Id == mealId && m.PlanId == planId);
            if (meal == null)
                return NotFound($"Meal {mealId} not found in plan {planId}.");

            meal.PlanId = null;
            return Ok(meal);
        }
    }
}
