using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private static List<Ingredient> ingredients = new List<Ingredient>
        {
            // existing ingredients
            new Ingredient { Id = 1, Name = "Chicken", Price = 8.99m, Origin = "Ireland", IsOrganic = true, Fats = 3.6, Protein = 31.0 },
            new Ingredient { Id = 2, Name = "Rice", Price = 2.50m, Origin = "Italy", IsOrganic = false, Fats = 0.3, Protein = 2.7 },
            new Ingredient { Id = 3, Name = "Tomato", Price = 1.20m, Origin = "Spain", IsOrganic = true, Fats = 0.2, Protein = 0.9 },
            new Ingredient { Id = 4, Name = "Cheese", Price = 5.75m, Origin = "France", IsOrganic = false, Fats = 33.0, Protein = 25.0 },
            new Ingredient { Id = 5, Name = "Pasta", Price = 1.99m, Origin = "Italy", IsOrganic = true, Fats = 1.5, Protein = 13.0 },
            new Ingredient { Id = 6, Name = "Tomato", Price = 2.49m, Origin = "Italy", IsOrganic = true, Fats = 0.2, Protein = 0.9 },
            new Ingredient { Id = 7, Name = "Garlic", Price = 1.79m, Origin = "Italy", IsOrganic = false, Fats = 0.5, Protein = 6.4 },
            new Ingredient { Id = 8, Name = "Parmesan", Price = 3.99m, Origin = "Italy", IsOrganic = true, Fats = 29.0, Protein = 35.8 },
            new Ingredient { Id = 9, Name = "Basil", Price = 1.49m, Origin = "Italy", IsOrganic = true, Fats = 0.6, Protein = 3.2 },
            new Ingredient { Id = 10, Name = "Olive Oil", Price = 4.99m, Origin = "Italy", IsOrganic = false, Fats = 100.0, Protein = 0.0 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
        {
            return Ok(ingredients);
        }


        // smart search - eg., "find me a ingredient thats cheap up ,from irelnd , to this expense, have this amount of protein  "
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
            // name , origin , minprice  , maxprce, min ,protein 
            var result = ingredients.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(origin))
                result = result.Where(i => i.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase));
            if (minPrice.HasValue) result = result.Where(i => i.Price >= minPrice.Value);
            if (maxPrice.HasValue) result = result.Where(i => i.Price <= maxPrice.Value);
            if (minProtein.HasValue) result = result.Where(i => i.Protein >= minProtein.Value);
            
            // min fats etc., not in ill do another type of smart search 
            return Ok(result);
        }






        // 5 singlular  search gets 
        [HttpGet("search/name/{name}")]
        public ActionResult<IEnumerable<Ingredient>> GetByName(string name)
        {
            var result = ingredients.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpGet("search/origin/{origin}")]
        public ActionResult<IEnumerable<Ingredient>> GetByOrigin(string origin)
        {
            var result = ingredients.Where(i => i.Origin.Equals(origin, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }

        [HttpGet("search/price/{maxPrice}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMaxPrice(decimal maxPrice)
        {
            var result = ingredients.Where(i => i.Price <= maxPrice);
            return Ok(result);
        }

        [HttpGet("search/protein/{minProtein}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMinProtein(double minProtein)
        {
            var result = ingredients.Where(i => i.Protein >= minProtein);
            return Ok(result);
        }

        [HttpGet("search/fat/{minFat}")]
        public ActionResult<IEnumerable<Ingredient>> GetByMinFat(double minFat)
        {
            var result = ingredients.Where(i => i.Fats >= minFat);
            return Ok(result);
        }


        // get ingreints by id 
        [HttpGet("{id}")]
        public ActionResult<Ingredient> GetIngredientById(int id)
        {
            var ingredient = ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
                return NotFound();

            return Ok(ingredient);
        }

        // get by organic 
        [HttpGet("organic")]
        public ActionResult<IEnumerable<Ingredient>> GetOrganic(bool? isOrganic = true)
        {
            var result = ingredients.Where(i => i.IsOrganic == isOrganic);
            return Ok(result);
        }



        // page 
        [HttpGet("page")]
        public ActionResult<IEnumerable<Ingredient>> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = ingredients.Skip((page - 1) * pageSize).Take(pageSize);
            return Ok(result);
        }

        // new Put method
        [HttpPut("{id}")]
        public ActionResult UpdateIngredient(int id, Ingredient updatedIngredient)
        {
            var ingredientIndex = ingredients.FindIndex(i => i.Id == id);

            if (ingredientIndex == -1)
                return NotFound();

            ingredients[ingredientIndex] = updatedIngredient;

            return Ok(ingredients[ingredientIndex]);
        }

        // new simple Put method
        [HttpPut("simple-update")]
        public ActionResult SimpleUpdateIngredient(int id, Ingredient simpleUpdatedIngredient)
        {
            var ingredientIndex = ingredients.FindIndex(i => i.Id == id);

            if (ingredientIndex == -1)
                return NotFound();

            ingredients[ingredientIndex].Name = simpleUpdatedIngredient.Name;
            ingredients[ingredientIndex].Price = simpleUpdatedIngredient.Price;

            return Ok(ingredients[ingredientIndex]);
        }
    }
}
