using CA1_BackEnd.Data;
using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        // BEFORE: private static List<Meal> meals => DataStore.Meals;
        // AFTER:  inject AppDbContext — ASP.NET Core hands this to us automatically
        private readonly AppDbContext _context;

        public MealsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Meal>> GetAllMeals()
        {
            // BEFORE: return Ok(meals);
            // AFTER:  .ToList() executes the SQL query and returns the results
            return Ok(_context.Meals.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Meal> GetMealById(int id)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
                return NotFound();

            return Ok(meal);
        }

        [HttpGet("search/name/{name}")]
        public ActionResult<IEnumerable<Meal>> GetByName(string name)
        {
            var result = _context.Meals.Where(m => m.Name.ToLower().Contains(name.ToLower()));
            return Ok(result.ToList());
        }

        [HttpGet("search/category/{category}")]
        public ActionResult<IEnumerable<Meal>> GetByCategory(string category)
        {
            var result = _context.Meals.Where(m => m.Category.ToLower() == category.ToLower());
            return Ok(result.ToList());
        }

        [HttpGet("search/totalFat/{totalFat}")]
        public ActionResult<IEnumerable<Meal>> GetByTotalFat(double totalFat)
        {
            var result = _context.Meals.Where(m => m.TotalFat == totalFat);
            return Ok(result.ToList());
        }

        [HttpGet("search/rating/{rating}")]
        public ActionResult<IEnumerable<Meal>> GetByRating(double rating)
        {
            var result = _context.Meals.Where(m => m.Rating == rating);
            return Ok(result.ToList());
        }

        [HttpGet("search/difficulty/{difficulty}")]
        public ActionResult<IEnumerable<Meal>> GetByDifficulty(string difficulty)
        {
            var result = _context.Meals.Where(m => m.Difficulty.ToLower() == difficulty.ToLower());
            return Ok(result.ToList());
        }

        [HttpGet("search/prepTime/{prepTime}")]
        public ActionResult<IEnumerable<Meal>> GetByPrepTime(int prepTime)
        {
            var result = _context.Meals.Where(m => m.PrepTime == prepTime);
            return Ok(result.ToList());
        }

        [HttpGet("search/cookTime/{cookTime}")]
        public ActionResult<IEnumerable<Meal>> GetByCookTime(int cookTime)
        {
            var result = _context.Meals.Where(m => m.CookTime == cookTime);
            return Ok(result.ToList());
        }

        [HttpGet("search/servings/{servings}")]
        public ActionResult<IEnumerable<Meal>> GetByServings(int servings)
        {
            var result = _context.Meals.Where(m => m.Servings == servings);
            return Ok(result.ToList());
        }

        [HttpGet("search/calories/{calories}")]
        public ActionResult<IEnumerable<Meal>> GetByCalories(double calories)
        {
            var result = _context.Meals.Where(m => m.Calories == calories);
            return Ok(result.ToList());
        }

        [HttpGet("search/minprotein/{minProtein}")]
        public ActionResult<IEnumerable<Meal>> GetByMinProtein(double minProtein)
        {
            var result = _context.Meals.Where(m => m.Protein >= minProtein);
            return Ok(result.ToList());
        }

        [HttpGet("search/protein/{protein}")]
        public ActionResult<IEnumerable<Meal>> GetByProtein(double protein)
        {
            var result = _context.Meals.Where(m => m.Protein == protein);
            return Ok(result.ToList());
        }

        [HttpPost]
        public ActionResult<Meal> CreateMeal([FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // BEFORE: meals.Add(meal);  — added to RAM list, gone on restart
            // AFTER:  Add to DbContext then SaveChanges() writes it to the .db file
            _context.Meals.Add(meal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMealById), new { id = meal.Id }, meal);
        }

        [HttpPut("{id}")]
        public ActionResult<Meal> UpdateMeal(int id, [FromBody] Meal updatedMeal)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == id);
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

            // EF is tracking the meal object — SaveChanges() detects what changed and writes it
            _context.SaveChanges();

            return Ok(meal);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMeal(int id)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == id);
            if (meal == null)
                return NotFound();

            _context.Meals.Remove(meal);
            _context.SaveChanges();

            return Ok(meal);
        }

        [HttpGet("{mealId}/ingredients")]
        public ActionResult<IEnumerable<Ingredient>> GetMealIngredients(int mealId)
        {
            var ingredients = _context.Ingredients.Where(i => i.MealId == mealId).ToList();
            return Ok(ingredients);
        }

        [HttpPost("{mealId}/ingredients")]
        public ActionResult<Ingredient> AddIngredientToMeal(int mealId, [FromBody] Ingredient ingredient)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            if (meal == null)
                return NotFound();

            ingredient.MealId = mealId;
            _context.Ingredients.Add(ingredient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetMealIngredients), new { mealId = mealId }, ingredient);
        }

        [HttpPut("{mealId}/ingredients")]
        public ActionResult SetMealIngredients(int mealId, [FromBody] List<Ingredient> ingredients)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            if (meal == null)
                return NotFound();

            var existing = _context.Ingredients.Where(i => i.MealId == mealId).ToList();
            _context.Ingredients.RemoveRange(existing);

            foreach (var ing in ingredients)
            {
                ing.MealId = mealId;
                ing.Id = 0;
                _context.Ingredients.Add(ing);
            }
            _context.SaveChanges();

            return Ok(_context.Ingredients.Where(i => i.MealId == mealId).ToList());
        }

        [HttpPost("{mealId}/ingredients/random")]
        public ActionResult<IEnumerable<Ingredient>> AddRandomIngredients(int mealId, [FromQuery] int count = 3)
        {
            var meal = _context.Meals.FirstOrDefault(m => m.Id == mealId);
            if (meal == null)
                return NotFound();

            var allIngredients = _context.Ingredients.ToList();
            var existing = _context.Ingredients.Where(i => i.MealId == mealId).ToList();
            _context.Ingredients.RemoveRange(existing);

            var random = new Random();
            var selected = allIngredients.OrderBy(x => random.Next()).Take(count).ToList();

            foreach (var ing in selected)
            {
                var newIng = new Ingredient
                {
                    Name = ing.Name,
                    Price = ing.Price,
                    Origin = ing.Origin,
                    IsOrganic = ing.IsOrganic,
                    Fats = ing.Fats,
                    Protein = ing.Protein,
                    Carbohydrates = ing.Carbohydrates,
                    Fiber = ing.Fiber,
                    IsVegetarian = ing.IsVegetarian,
                    EnergyContent = ing.EnergyContent,
                    ServingSize = ing.ServingSize,
                    CaloriesPerServing = ing.CaloriesPerServing,
                    NutrientGroups = ing.NutrientGroups,
                    SodiumContent = ing.SodiumContent,
                    MacronutrientComposition = ing.MacronutrientComposition,
                    DietaryFiberPercentage = ing.DietaryFiberPercentage,
                    CalorieDensity = ing.CalorieDensity,
                    MealId = mealId
                };
                _context.Ingredients.Add(newIng);
            }
            _context.SaveChanges();

            return Ok(_context.Ingredients.Where(i => i.MealId == mealId).ToList());
        }
    }
}
