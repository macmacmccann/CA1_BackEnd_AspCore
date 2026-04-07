namespace CA1_BackEnd.Models
{
    public class Ingredient
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required string Origin { get; set; }
        public bool IsOrganic { get; set; } // Changed from required to bool
        public double Fats { get; set; }
        public double Protein { get; set; }

        public double Carbohydrates { get; set; } // New property for carbohydrates
        public double Fiber { get; set; } // New property for fiber
        public string IsVegetarian { get; set; } // Changed from required to bool

        public double EnergyContent { get; set; } // Calories per serving
        public double ServingSize { get; set; } // Quantity of the ingredient used each time (grams, ounces, etc.)
        public double CaloriesPerServing { get; set; } // Calories per specified serving size
        public string NutrientGroups { get; set; } // Categories for macronutrients, vitamins, minerals, etc.
        public double SodiumContent { get; set; } // Sodium content in milligrams per serving
        public double MacronutrientComposition { get; set; } // Percentage breakdown of carbs, proteins, fats
        public double DietaryFiberPercentage { get; set; } // Percentage of dietary fiber compared to total carbohydrates
        public double CalorieDensity { get; set; } // Calories per gram or unit volume

    
    }
}
