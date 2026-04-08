using CA1_BackEnd.Data;
using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Plan>> GetAllPlans()
        {
            return Ok(_context.Plans.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Plan> GetPlanById(int id)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            return Ok(plan);
        }

        [HttpGet("{id}/meals")]
        public ActionResult<IEnumerable<Meal>> GetMealsByPlan(int id)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            var planMeals = _context.Meals.Where(m => m.PlanId == id).ToList();
            return Ok(planMeals);
        }

        [HttpPost]
        public ActionResult<Plan> CreatePlan([FromBody] Plan plan)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Plans.Add(plan);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlanById), new { id = plan.Id }, plan);
        }

        [HttpPut("{id}")]
        public ActionResult<Plan> UpdatePlan(int id, [FromBody] Plan updatedPlan)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            plan.Name = updatedPlan.Name;
            plan.Description = updatedPlan.Description;

            _context.SaveChanges();

            return Ok(plan);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePlan(int id)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == id);
            if (plan == null)
                return NotFound();

            // Unlink meals from this plan before deleting
            var linkedMeals = _context.Meals.Where(m => m.PlanId == id).ToList();
            foreach (var meal in linkedMeals)
                meal.PlanId = null;

            _context.Plans.Remove(plan);
            _context.SaveChanges();

            return Ok(plan);
        }

        [HttpPost("{planId}/meals/{mealId}")]
        public ActionResult AssignMealToPlan(int planId, int mealId)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == planId);
            if (plan == null)
                return NotFound($"Plan {planId} not found.");

            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            if (meal == null)
                return NotFound($"Meal {mealId} not found.");

            meal.PlanId = planId;
            _context.SaveChanges();

            return Ok(meal);
        }

        [HttpDelete("{planId}/meals/{mealId}")]
        public ActionResult RemoveMealFromPlan(int planId, int mealId)
        {
            var plan = _context.Plans.FirstOrDefault(p => p.Id == planId);
            if (plan == null)
                return NotFound($"Plan {planId} not found.");

            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId && m.PlanId == planId);
            if (meal == null)
                return NotFound($"Meal {mealId} not found in plan {planId}.");

            meal.PlanId = null;
            _context.SaveChanges();

            return Ok(meal);
        }
    }
}
