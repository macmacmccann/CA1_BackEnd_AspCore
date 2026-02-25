namespace CA1_BackEnd.Models
{
    public class Ingredient
    {
        public required int  Id { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required  string Origin { get; set; }
        public required bool IsOrganic { get; set; }
        public required  double Fats { get; set; }
        public required double Protein { get; set; }
    }
}
