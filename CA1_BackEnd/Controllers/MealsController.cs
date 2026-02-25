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
            new Meal { Id = 1, Name = "Grilled Chicken Salad", Picture = "chicken-salad.jpg", TotalFat = 12.5, Rating = 4.5, Difficulty = "Easy", PrepTime = 15, CookTime = 20, Servings = 2, Calories = 350, Protein = 35, Category = "Lunch" },
            new Meal { Id = 2, Name = "Spaghetti Carbonara", Picture = "carbonara.jpg", TotalFat = 28.0, Rating = 4.8, Difficulty = "Medium", PrepTime = 10, CookTime = 25, Servings = 4, Calories = 580, Protein = 22, Category = "Dinner" },
            new Meal { Id = 3, Name = "Vegetable Stir Fry", Picture = "stir-fry.jpg", TotalFat = 8.5, Rating = 4.2, Difficulty = "Easy", PrepTime = 20, CookTime = 15, Servings = 3, Calories = 280, Protein = 12, Category = "Dinner" },
            new Meal { Id = 4, Name = "Pancakes", Picture = "pancakes.jpg", TotalFat = 15.0, Rating = 4.7, Difficulty = "Easy", PrepTime = 10, CookTime = 15, Servings = 4, Calories = 420, Protein = 10, Category = "Breakfast" },
            new Meal { Id = 5, Name = "Beef Tacos", Picture = "tacos.jpg", TotalFat = 22.0, Rating = 4.6, Difficulty = "Medium", PrepTime = 15, CookTime = 20, Servings = 4, Calories = 480, Protein = 28, Category = "Dinner" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Meal>> GetAllMeals()
        {
            return Ok(meals);
        }
    }
}
