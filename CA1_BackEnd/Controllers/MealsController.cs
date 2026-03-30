using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private static List<Meal> meals = new List<Meal>
        {
            // Existing meal objects...
            new Meal { Id = 6, Name = "Vegetable Fried Rice", Picture = "fried-rice.jpg", TotalFat = 10.5, Rating = 4.3, Difficulty = "Easy", PrepTime = 25, CookTime = 15, Servings = 4, Calories = 260, Protein = 9, Category = "Dinner" },
            new Meal { Id = 7, Name = "Chicken Curry", Picture = "chicken-curry.jpg", TotalFat = 24.0, Rating = 4.1, Difficulty = "Medium", PrepTime = 30, CookTime = 20, Servings = 5, Calories = 560, Protein = 38, Category = "Dinner" },
            new Meal { Id = 8, Name = "Fruit Salad", Picture = "fruit-salad.jpg", TotalFat = 1.5, Rating = 4.9, Difficulty = "Easy", PrepTime = 10, CookTime = 5, Servings = 2, Calories = 70, Protein = 6, Category = "Snack" }
        };

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

        // New search methods for each property
        [HttpGet("search/totalFat/{totalFat}")]
        public ActionResult<IEnumerable<Meal>> GetByTotalFat(double totalFat)
        {
            var result = meals.Where(m => m.TotalFat == totalFat);
            return Ok(result);
        }

        // get meals by rating
        [HttpGet("search/rating/{rating}")]
        public ActionResult<IEnumerable<Meal>> GetByRating(double rating)
        {
            var result = meals.Where(m => m.Rating == rating);
            return Ok(result);
        }

        // get meals by difficulty
        [HttpGet("search/difficulty/{difficulty}")]
        public ActionResult<IEnumerable<Meal>> GetByDifficulty(string difficulty)
        {
            var result = meals.Where(m => m.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        // get meals by prep time
        [HttpGet("search/prepTime/{prepTime}")]
        public ActionResult<IEnumerable<Meal>> GetByPrepTime(int prepTime)
        {
            var result = meals.Where(m => m.PrepTime == prepTime);
            return Ok(result);
        }

        // get meals by cook time
        [HttpGet("search/cookTime/{cookTime}")]
        public ActionResult<IEnumerable<Meal>> GetByCookTime(int cookTime)
        {
            var result = meals.Where(m => m.CookTime == cookTime);
            return Ok(result);
        }

        // get meals by servings
        [HttpGet("search/servings/{servings}")]
        public ActionResult<IEnumerable<Meal>> GetByServings(int servings)
        {
            var result = meals.Where(m => m.Servings == servings);
            return Ok(result);
        }

        // get meals by calories
        [HttpGet("search/calories/{calories}")]
        public ActionResult<IEnumerable<Meal>> GetByCalories(double calories)
        {
            var result = meals.Where(m => m.Calories == calories);
            return Ok(result);
        }

        // get meals by protein
        [HttpGet("search/protein/{protein}")]
        public ActionResult<IEnumerable<Meal>> GetByProtein(double protein)
        {
            var result = meals.Where(m => m.Protein == protein);
            return Ok(result);
        }
    }
}

