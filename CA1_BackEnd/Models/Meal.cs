namespace CA1_BackEnd.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public double TotalFat { get; set; }
        public double Rating { get; set; }
        public string Difficulty { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int Servings { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public string Category { get; set; }
    }
}
