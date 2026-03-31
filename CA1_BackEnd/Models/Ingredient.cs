namespace CA1_BackEnd.Models
{
    public class Ingredient
    {
        public required int  Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required  string Origin { get; set; }
        public bool IsOrganic { get; set; } // Changed from required to bool
        public double Fats { get; set; }
        public double Protein { get; set; }

        public double Carbohydrates { get; set; } // New property for carbohydrates
        public double Fiber { get; set; } // New property for fiber
       
        public string IsVegetarian { get; set; } // Changed from required to bool for better usage
    
    //
    //
    //
    //
    
    }
}

