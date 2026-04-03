// hi
// hi again - testing file editing

namespace CA1_BackEnd.Models
{
    public class Meal
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Picture { get; set; }
        public required double TotalFat { get; set; }
        public double? Rating { get; set; }
        public required string Difficulty { get; set; }
        public required int PrepTime { get; set; }
        public required int CookTime { get; set; }
        public required int Servings { get; set; }
        public required double Calories { get; set; }
        public required double Protein { get; set; }
        public required string Category { get; set; }
        public string? Description { get; set; } 
        public bool IsVegetarian { get; set; }

        public double TotalProtein { get; set; }

       public double TotalCarbohydrates { get; set; } // New property for total carbohydrates
       public double TotalFiber { get; set; } // New property for total fiber

        public double TotalCholesterol { get; set; } // New property for total cholesterol

  
    }
}

