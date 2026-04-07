namespace CA1_BackEnd.Models
{
    public class Plan
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
