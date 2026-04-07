using CA1_BackEnd.Models;

namespace CA1_BackEnd.Data
{
    public static class DataStore
    {
        public static List<Meal> Meals { get; } = new List<Meal>
        {
            new Meal { Id = 6, Name = "Vegetable Fried Rice", Picture = "fried-rice.jpg", TotalFat = 10.5, Rating = 4.3, Difficulty = "Easy", PrepTime = 25, CookTime = 15, Servings = 4, Calories = 260, Protein = 9, Category = "Dinner" },
            new Meal { Id = 7, Name = "Chicken Curry", Picture = "chicken-curry.jpg", TotalFat = 24.0, Rating = 4.1, Difficulty = "Medium", PrepTime = 30, CookTime = 20, Servings = 5, Calories = 560, Protein = 38, Category = "Dinner" },
            new Meal { Id = 8, Name = "Fruit Salad", Picture = "fruit-salad.jpg", TotalFat = 1.5, Rating = 4.9, Difficulty = "Easy", PrepTime = 10, CookTime = 5, Servings = 2, Calories = 70, Protein = 6, Category = "Snack" }
        };

        public static List<Plan> Plans { get; } = new List<Plan>
        {
            new Plan { Id = 1, Name = "Healthy Week", Description = "A balanced weekly meal plan" },
            new Plan { Id = 2, Name = "High Protein", Description = "Meals focused on high protein intake" }
        };
    }
}
