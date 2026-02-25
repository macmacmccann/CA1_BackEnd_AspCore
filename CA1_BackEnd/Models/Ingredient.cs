namespace CA1_BackEnd.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Origin { get; set; }
        public bool IsOrganic { get; set; }
        public double Fats { get; set; }
        public double Protein { get; set; }
    }
}
