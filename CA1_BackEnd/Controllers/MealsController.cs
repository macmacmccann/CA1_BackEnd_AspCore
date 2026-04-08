using CA1_BackEnd.Data;
using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private static List<Meal> meals => DataStore.Meals;

        [HttpGet]
        public ActionResult<IEnumerable<Meal>> GetAllMeals()
        {
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public ActionResult<Meal> GetMealById(int id)
        {
            var meal = meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
                return NotFound();

            return Ok(meal);
        }

        [HttpGet("search/name/{name}")]
        public ActionResult<IEnumerable<Meal>> GetByName(string name)
        {
            var result = meals.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpGet("search/category/{category}")]
        public ActionResult<IEnumerable<Meal>> GetByCategory(string category)
        {
            var result = meals.Where(m => m.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpGet("search/totalFat/{totalFat}")]
        public ActionResult<IEnumerable<Meal>> GetByTotalFat(double totalFat)
        {
            var result = meals.Where(m => m.TotalFat == totalFat);
            return Ok(result);
        }

        [HttpGet("search/rating/{rating}")]
        public ActionResult<IEnumerable<Meal>> GetByRating(double rating)
        {
            var result = meals.Where(m => m.Rating == rating);
            return Ok(result);
        }

        [HttpGet("search/difficulty/{difficulty}")]
        public ActionResult<IEnumerable<Meal>> GetByDifficulty(string difficulty)
        {
            var result = meals.Where(m => m.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpGet("search/prepTime/{prepTime}")]
        public ActionResult<IEnumerable<Meal>> GetByPrepTime(int prepTime)
        {
            var result = meals.Where(m => m.PrepTime == prepTime);
            return Ok(result);
        }

        [HttpGet("search/cookTime/{cookTime}")]
        public ActionResult<IEnumerable<Meal>> GetByCookTime(int cookTime)
        {
            var result = meals.Where(m => m.CookTime == cookTime);
            return Ok(result);
        }

        [HttpGet("search/servings/{servings}")]
        public ActionResult<IEnumerable<Meal>> GetByServings(int servings)
        {
            var result = meals.Where(m => m.Servings == servings);
            return Ok(result);
        }

        [HttpGet("search/calories/{calories}")]
        public ActionResult<IEnumerable<Meal>> GetByCalories(double calories)
        {
            var result = meals.Where(m => m.Calories == calories);
            return Ok(result);
        }

        [HttpGet("search/minprotein/{minProtein}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMinProtein(double minProtein)
        {
            var result = meals.Where(i => i.Protein >= minProtein);
            return Ok(result);
        }




        [HttpGet("search/protein/{protein}")]
        public ActionResult<IEnumerable<Meal>> GetByProtein(double protein)
        {
            var result = meals.Where(m => m.Protein == protein);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<Meal> CreateMeal([FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            meals.Add(meal);
            return CreatedAtAction(nameof(GetMealById), new { id = meal.Id }, meal);
        }

        [HttpPut("{id}")]
        public ActionResult<Meal> UpdateMeal(int id, [FromBody] Meal updatedMeal)
        {
            var meal = meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            meal.Name = updatedMeal.Name;
            meal.Picture = updatedMeal.Picture;
            meal.TotalFat = updatedMeal.TotalFat;
            meal.Rating = updatedMeal.Rating;
            meal.Difficulty = updatedMeal.Difficulty;
            meal.PrepTime = updatedMeal.PrepTime;
            meal.CookTime = updatedMeal.CookTime;
            meal.Servings = updatedMeal.Servings;
            meal.Calories = updatedMeal.Calories;
            meal.Protein = updatedMeal.Protein;
            meal.Category = updatedMeal.Category;
            meal.PlanId = updatedMeal.PlanId;

            return Ok(meal);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMeal(int id)
        {
            var meal = meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
                return NotFound();

            meals.Remove(meal);
            return Ok(meal);
        }
    }
}
