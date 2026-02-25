using CA1_BackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CA1_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Ingredient>> GetAllIngredients()
        {
            var ingredients = new List<Ingredient>
            {
                new Ingredient { Id = 1, Name = "Chicken", Price = 8.99m, Origin = "Ireland", IsOrganic = true, Fats = 3.6, Protein = 31.0 },
                new Ingredient { Id = 2, Name = "Rice", Price = 2.50m, Origin = "Italy", IsOrganic = false, Fats = 0.3, Protein = 2.7 },
                new Ingredient { Id = 3, Name = "Tomato", Price = 1.20m, Origin = "Spain", IsOrganic = true, Fats = 0.2, Protein = 0.9 },
                new Ingredient { Id = 4, Name = "Cheese", Price = 5.75m, Origin = "France", IsOrganic = false, Fats = 33.0, Protein = 25.0 },
                new Ingredient { Id = 5, Name = "Pasta", Price = 1.99m, Origin = "Italy", IsOrganic = true, Fats = 1.5, Protein = 13.0 }
            };

            return Ok(ingredients);
        }
    }
}
