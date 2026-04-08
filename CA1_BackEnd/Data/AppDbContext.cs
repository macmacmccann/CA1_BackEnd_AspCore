using CA1_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace CA1_BackEnd.Data
{
    public class AppDbContext : DbContext
    {
        // DbContextOptions lets Program.cs tell this class which database to use
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Each DbSet maps to a table in the database
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // HasData seeds the database on the first migration — same data as DataStore.cs
            // but now EF writes it into the .db file once and it stays there permanently

            modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 1, Name = "Healthy Week", Description = "A balanced weekly meal plan" },
                new Plan { Id = 2, Name = "High Protein", Description = "Meals focused on high protein intake" }
            );

            modelBuilder.Entity<Meal>().HasData(
                // Breakfast
                new Meal { Id = 9,  Name = "Pancakes",          Picture = "pancakes.jpg",          TotalFat = 8.5,  Rating = 4.5, Difficulty = "Easy",   PrepTime = 15, CookTime = 10, Servings = 3, Calories = 210, Protein = 6,  Category = "Breakfast" },
                new Meal { Id = 10, Name = "Omelette",          Picture = "omelette.jpg",          TotalFat = 12.0, Rating = 4.2, Difficulty = "Easy",   PrepTime = 10, CookTime = 8,  Servings = 2, Calories = 180, Protein = 22, Category = "Breakfast" },
                new Meal { Id = 11, Name = "French Toast",      Picture = "french-toast.jpg",      TotalFat = 9.0,  Rating = 4.4, Difficulty = "Easy",   PrepTime = 10, CookTime = 10, Servings = 2, Calories = 220, Protein = 7,  Category = "Breakfast" },
                new Meal { Id = 12, Name = "Breakfast Burrito", Picture = "breakfast-burrito.jpg", TotalFat = 14.5, Rating = 4.3, Difficulty = "Medium", PrepTime = 20, CookTime = 10, Servings = 2, Calories = 320, Protein = 14, Category = "Breakfast" },
                new Meal { Id = 13, Name = "Smoothie Bowl",     Picture = "smoothie-bowl.jpg",     TotalFat = 5.0,  Rating = 4.8, Difficulty = "Easy",   PrepTime = 10, CookTime = 0,  Servings = 1, Calories = 180, Protein = 37, Category = "Breakfast" },
                new Meal { Id = 14, Name = "Avocado Toast",     Picture = "avocado-toast.jpg",     TotalFat = 11.0, Rating = 4.6, Difficulty = "Easy",   PrepTime = 5,  CookTime = 5,  Servings = 1, Calories = 190, Protein = 4,  Category = "Breakfast" },
                new Meal { Id = 15, Name = "Granola Yogurt",    Picture = "granola-yogurt.jpg",    TotalFat = 6.0,  Rating = 4.7, Difficulty = "Easy",   PrepTime = 5,  CookTime = 0,  Servings = 1, Calories = 160, Protein = 40, Category = "Breakfast" },
                new Meal { Id = 16, Name = "Scrambled Eggs",    Picture = "scrambled-eggs.jpg",    TotalFat = 10.0, Rating = 4.3, Difficulty = "Easy",   PrepTime = 5,  CookTime = 5,  Servings = 2, Calories = 150, Protein = 11, Category = "Breakfast" },
                new Meal { Id = 17, Name = "Breakfast Muffins", Picture = "breakfast-muffins.jpg", TotalFat = 7.5,  Rating = 4.2, Difficulty = "Medium", PrepTime = 20, CookTime = 20, Servings = 4, Calories = 230, Protein = 6,  Category = "Breakfast" },
                new Meal { Id = 18, Name = "Chia Pudding",      Picture = "chia-pudding.jpg",      TotalFat = 9.0,  Rating = 4.5, Difficulty = "Easy",   PrepTime = 10, CookTime = 0,  Servings = 2, Calories = 200, Protein = 6,  Category = "Breakfast" },

                // Lunch
                new Meal { Id = 19, Name = "Chicken Salad",          Picture = "chicken-salad.jpg",   TotalFat = 15.0, Rating = 4.3, Difficulty = "Easy",   PrepTime = 15, CookTime = 10, Servings = 3, Calories = 350, Protein = 25, Category = "Lunch" },
                new Meal { Id = 20, Name = "Grilled Cheese Sandwich", Picture = "grilled-cheese.jpg",  TotalFat = 18.0, Rating = 4.6, Difficulty = "Easy",   PrepTime = 5,  CookTime = 10, Servings = 1, Calories = 300, Protein = 10, Category = "Lunch" },
                new Meal { Id = 21, Name = "Turkey Wrap",             Picture = "turkey-wrap.jpg",     TotalFat = 9.5,  Rating = 4.2, Difficulty = "Easy",   PrepTime = 10, CookTime = 5,  Servings = 1, Calories = 270, Protein = 18, Category = "Lunch" },
                new Meal { Id = 22, Name = "Caesar Salad",            Picture = "caesar-salad.jpg",    TotalFat = 14.0, Rating = 4.1, Difficulty = "Easy",   PrepTime = 15, CookTime = 0,  Servings = 2, Calories = 240, Protein = 7,  Category = "Lunch" },
                new Meal { Id = 23, Name = "BLT Sandwich",            Picture = "blt.jpg",             TotalFat = 16.0, Rating = 4.4, Difficulty = "Easy",   PrepTime = 10, CookTime = 10, Servings = 1, Calories = 320, Protein = 12, Category = "Lunch" },
                new Meal { Id = 24, Name = "Veggie Wrap",             Picture = "veggie-wrap.jpg",     TotalFat = 7.0,  Rating = 4.5, Difficulty = "Easy",   PrepTime = 10, CookTime = 0,  Servings = 1, Calories = 210, Protein = 6,  Category = "Lunch" },
                new Meal { Id = 25, Name = "Tomato Soup",             Picture = "tomato-soup.jpg",     TotalFat = 5.5,  Rating = 4.3, Difficulty = "Easy",   PrepTime = 10, CookTime = 20, Servings = 3, Calories = 150, Protein = 4,  Category = "Lunch" },
                new Meal { Id = 26, Name = "Chicken Wrap",            Picture = "chicken-wrap.jpg",    TotalFat = 11.0, Rating = 4.4, Difficulty = "Easy",   PrepTime = 10, CookTime = 10, Servings = 1, Calories = 290, Protein = 20, Category = "Lunch" },
                new Meal { Id = 27, Name = "Pasta Salad",             Picture = "pasta-salad.jpg",     TotalFat = 12.5, Rating = 4.2, Difficulty = "Easy",   PrepTime = 15, CookTime = 10, Servings = 3, Calories = 330, Protein = 9,  Category = "Lunch" },
                new Meal { Id = 28, Name = "Quinoa Bowl",             Picture = "quinoa-bowl.jpg",     TotalFat = 8.0,  Rating = 4.7, Difficulty = "Easy",   PrepTime = 15, CookTime = 15, Servings = 2, Calories = 260, Protein = 10, Category = "Lunch" },

                // Dinner
                new Meal { Id = 29, Name = "Spaghetti Bolognese", Picture = "spaghetti.jpg",       TotalFat = 20.0, Rating = 4.6, Difficulty = "Medium", PrepTime = 20, CookTime = 25, Servings = 4, Calories = 480, Protein = 22, Category = "Dinner" },
                new Meal { Id = 30, Name = "Grilled Salmon",      Picture = "salmon.jpg",          TotalFat = 18.0, Rating = 4.8, Difficulty = "Medium", PrepTime = 15, CookTime = 15, Servings = 2, Calories = 420, Protein = 34, Category = "Dinner" },
                new Meal { Id = 31, Name = "Beef Stir Fry",       Picture = "beef-stir-fry.jpg",   TotalFat = 16.5, Rating = 4.5, Difficulty = "Medium", PrepTime = 20, CookTime = 15, Servings = 3, Calories = 390, Protein = 28, Category = "Dinner" },
                new Meal { Id = 32, Name = "Vegetable Curry",     Picture = "veg-curry.jpg",       TotalFat = 13.0, Rating = 4.4, Difficulty = "Medium", PrepTime = 20, CookTime = 20, Servings = 4, Calories = 310, Protein = 9,  Category = "Dinner" },
                new Meal { Id = 33, Name = "Chicken Alfredo",     Picture = "alfredo.jpg",         TotalFat = 22.0, Rating = 4.6, Difficulty = "Medium", PrepTime = 20, CookTime = 20, Servings = 3, Calories = 550, Protein = 30, Category = "Dinner" },
                new Meal { Id = 34, Name = "Shrimp Tacos",        Picture = "shrimp-tacos.jpg",    TotalFat = 14.0, Rating = 4.7, Difficulty = "Medium", PrepTime = 15, CookTime = 10, Servings = 3, Calories = 360, Protein = 20, Category = "Dinner" },
                new Meal { Id = 35, Name = "Stuffed Peppers",     Picture = "stuffed-peppers.jpg", TotalFat = 10.0, Rating = 4.3, Difficulty = "Medium", PrepTime = 25, CookTime = 30, Servings = 4, Calories = 280, Protein = 12, Category = "Dinner" },
                new Meal { Id = 36, Name = "Lamb Chops",          Picture = "lamb-chops.jpg",      TotalFat = 25.0, Rating = 4.5, Difficulty = "Hard",   PrepTime = 20, CookTime = 20, Servings = 2, Calories = 600, Protein = 35, Category = "Dinner" },
                new Meal { Id = 37, Name = "Baked Cod",           Picture = "baked-cod.jpg",       TotalFat = 9.0,  Rating = 4.4, Difficulty = "Easy",   PrepTime = 10, CookTime = 20, Servings = 2, Calories = 250, Protein = 28, Category = "Dinner" },
                new Meal { Id = 38, Name = "Mushroom Risotto",    Picture = "risotto.jpg",         TotalFat = 17.0, Rating = 4.6, Difficulty = "Medium", PrepTime = 15, CookTime = 30, Servings = 3, Calories = 410, Protein = 10, Category = "Dinner" }
            );
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1,  Name = "Chicken",    Price = 8.99m,  Origin = "Ireland", IsOrganic = true,  Fats = 3.6,   Protein = 31.0 },
                new Ingredient { Id = 2,  Name = "Rice",       Price = 2.50m,  Origin = "Italy",   IsOrganic = false, Fats = 0.3,   Protein = 2.7  },
                new Ingredient { Id = 3,  Name = "Tomato",     Price = 1.20m,  Origin = "Spain",   IsOrganic = true,  Fats = 0.2,   Protein = 0.9  },
                new Ingredient { Id = 4,  Name = "Cheese",     Price = 5.75m,  Origin = "France",  IsOrganic = false, Fats = 33.0,  Protein = 25.0 },
                new Ingredient { Id = 5,  Name = "Pasta",      Price = 1.99m,  Origin = "Italy",   IsOrganic = true,  Fats = 1.5,   Protein = 13.0 },
                new Ingredient { Id = 6,  Name = "Tomato",     Price = 2.49m,  Origin = "Italy",   IsOrganic = true,  Fats = 0.2,   Protein = 0.9  },
                new Ingredient { Id = 7,  Name = "Garlic",     Price = 1.79m,  Origin = "Italy",   IsOrganic = false, Fats = 0.5,   Protein = 6.4  },
                new Ingredient { Id = 8,  Name = "Parmesan",   Price = 3.99m,  Origin = "Italy",   IsOrganic = true,  Fats = 29.0,  Protein = 35.8 },
                new Ingredient { Id = 9,  Name = "Basil",      Price = 1.49m,  Origin = "Italy",   IsOrganic = true,  Fats = 0.6,   Protein = 3.2  },
                new Ingredient { Id = 10, Name = "Olive Oil",  Price = 4.99m,  Origin = "Italy",   IsOrganic = false, Fats = 100.0, Protein = 0.0  }
            );
        }
    }
}
