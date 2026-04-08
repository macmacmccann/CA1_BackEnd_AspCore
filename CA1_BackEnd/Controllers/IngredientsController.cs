using CA1_BackEnd.Data;
using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        // BEFORE: private static List<Ingredient> ingredients = new List<Ingredient> { ... }
        // The seed data has moved to AppDbContext.OnModelCreating — it lives in the .db file now
        private readonly AppDbContext _context;

        public IngredientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return Ok(_context.Ingredients.ToList());
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<Ingredient>> Search(
            [FromQuery] string? name = null,
            [FromQuery] string? origin = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] double? minProtein = null,
            [FromQuery] double? maxProtein = null,
            [FromQuery] double? minFats = null,
            [FromQuery] double? maxFats = null)
        {
            // IQueryable means the filters build up as SQL — nothing hits the database
            // until .ToList() is called at the end
            var result = _context.Ingredients.AsQueryable();

            // NOTE: StringComparison.OrdinalIgnoreCase cannot be translated to SQL
            // so we use .ToLower() on both sides instead — EF Core can translate that
            if (!string.IsNullOrEmpty(name))
                result = result.Where(i => i.Name.ToLower().Contains(name.ToLower()));
            if (!string.IsNullOrEmpty(origin))
                result = result.Where(i => i.Origin.ToLower() == origin.ToLower());
            if (minPrice.HasValue) result = result.Where(i => i.Price >= minPrice.Value);
            if (maxPrice.HasValue) result = result.Where(i => i.Price <= maxPrice.Value);
            if (minProtein.HasValue) result = result.Where(i => i.Protein >= minProtein.Value);
            if (maxProtein.HasValue) result = result.Where(i => i.Protein <= maxProtein.Value);
            if (minFats.HasValue) result = result.Where(i => i.Fats >= minFats.Value);
            if (maxFats.HasValue) result = result.Where(i => i.Fats <= maxFats.Value);

            return Ok(result.ToList());
        }

        [HttpGet("search/name/{name}")]
        public ActionResult<IEnumerable<Ingredient>> GetByName(string name)
        {
            var result = _context.Ingredients.Where(i => i.Name.ToLower().Contains(name.ToLower()));
            return Ok(result.ToList());
        }

        [HttpGet("search/origin/{origin}")]
        public ActionResult<IEnumerable<Ingredient>> GetByOrigin(string origin)
        {
            var result = _context.Ingredients.Where(i => i.Origin.ToLower() == origin.ToLower());
            return Ok(result.ToList());
        }

        [HttpGet("search/price/{maxPrice}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMaxPrice(decimal maxPrice)
        {
            var result = _context.Ingredients.Where(i => i.Price <= maxPrice);
            return Ok(result.ToList());
        }

        [HttpGet("search/protein/{minProtein}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMinProtein(double minProtein)
        {
            var result = _context.Ingredients.Where(i => i.Protein >= minProtein);
            return Ok(result.ToList());
        }

        [HttpGet("search/fat/{minFat}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMinFat(double minFat)
        {
            var result = _context.Ingredients.Where(i => i.Fats >= minFat);
            return Ok(result.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredientById(int id)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return NotFound();

            return Ok(ingredient);
        }

        [HttpGet("organic")]
        public ActionResult<IEnumerable<Ingredient>> GetOrganic(bool? isOrganic = true)
        {
            var result = _context.Ingredients.Where(i => i.IsOrganic == isOrganic);
            return Ok(result.ToList());
        }

        [HttpGet("page")]
        public ActionResult<IEnumerable<Ingredient>> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = _context.Ingredients.Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(result.ToList());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateIngredient(int id, Ingredient updatedIngredient)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return NotFound();

            // BEFORE: ingredients[ingredientIndex] = updatedIngredient;
            // AFTER:  update each field on the tracked entity then SaveChanges()
            ingredient.Name = updatedIngredient.Name;
            ingredient.Price = updatedIngredient.Price;
            ingredient.Origin = updatedIngredient.Origin;
            ingredient.IsOrganic = updatedIngredient.IsOrganic;
            ingredient.Fats = updatedIngredient.Fats;
            ingredient.Protein = updatedIngredient.Protein;

            _context.SaveChanges();

            return Ok(ingredient);
        }

        [HttpPut("simple-update")]
        public ActionResult SimpleUpdateIngredient(int id, Ingredient simpleUpdatedIngredient)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return NotFound();

            ingredient.Name = simpleUpdatedIngredient.Name;
            ingredient.Price = simpleUpdatedIngredient.Price;

            _context.SaveChanges();

            return Ok(ingredient);
        }

        [HttpPost]
        public ActionResult AddIngredient(Ingredient newIngredient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            _context.Ingredients.Add(newIngredient);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetIngredientById), new { id = newIngredient.Id }, newIngredient);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveIngredient(int id)
        {
            var ingredient = _context.Ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return NotFound();

            _context.Ingredients.Remove(ingredient);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("isOrganic/{isOrganic}")]
        public ActionResult<IEnumerable<Ingredient>> GetByIsOrganic(bool isOrganic)
        {
            var result = _context.Ingredients.Where(i => i.IsOrganic == isOrganic);
            return Ok(result.ToList());
        }
    }
}
