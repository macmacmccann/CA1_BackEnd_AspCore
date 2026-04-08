using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CA1_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    IsOrganic = table.Column<bool>(type: "INTEGER", nullable: false),
                    Fats = table.Column<double>(type: "REAL", nullable: false),
                    Protein = table.Column<double>(type: "REAL", nullable: false),
                    Carbohydrates = table.Column<double>(type: "REAL", nullable: false),
                    Fiber = table.Column<double>(type: "REAL", nullable: false),
                    IsVegetarian = table.Column<string>(type: "TEXT", nullable: false),
                    EnergyContent = table.Column<double>(type: "REAL", nullable: false),
                    ServingSize = table.Column<double>(type: "REAL", nullable: false),
                    CaloriesPerServing = table.Column<double>(type: "REAL", nullable: false),
                    NutrientGroups = table.Column<string>(type: "TEXT", nullable: false),
                    SodiumContent = table.Column<double>(type: "REAL", nullable: false),
                    MacronutrientComposition = table.Column<double>(type: "REAL", nullable: false),
                    DietaryFiberPercentage = table.Column<double>(type: "REAL", nullable: false),
                    CalorieDensity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    TotalFat = table.Column<double>(type: "REAL", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: true),
                    Difficulty = table.Column<string>(type: "TEXT", nullable: false),
                    PrepTime = table.Column<int>(type: "INTEGER", nullable: false),
                    CookTime = table.Column<int>(type: "INTEGER", nullable: false),
                    Servings = table.Column<int>(type: "INTEGER", nullable: false),
                    Calories = table.Column<double>(type: "REAL", nullable: false),
                    Protein = table.Column<double>(type: "REAL", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsVegetarian = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    TotalProtein = table.Column<double>(type: "REAL", nullable: false),
                    TotalCarbohydrates = table.Column<double>(type: "REAL", nullable: false),
                    TotalFiber = table.Column<double>(type: "REAL", nullable: false),
                    TotalCholesterol = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CalorieDensity", "CaloriesPerServing", "Carbohydrates", "DietaryFiberPercentage", "EnergyContent", "Fats", "Fiber", "IsOrganic", "IsVegetarian", "MacronutrientComposition", "Name", "NutrientGroups", "Origin", "Price", "Protein", "ServingSize", "SodiumContent" },
                values: new object[,]
                {
                    { 1, 0.0, 0.0, 0.0, 0.0, 0.0, 3.6000000000000001, 0.0, true, "false", 0.0, "Chicken", "Protein", "Ireland", 8.99m, 31.0, 0.0, 0.0 },
                    { 2, 0.0, 0.0, 0.0, 0.0, 0.0, 0.29999999999999999, 0.0, false, "true", 0.0, "Rice", "Carbohydrates", "Italy", 2.50m, 2.7000000000000002, 0.0, 0.0 },
                    { 3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.20000000000000001, 0.0, true, "true", 0.0, "Tomato", "Vitamins", "Spain", 1.20m, 0.90000000000000002, 0.0, 0.0 },
                    { 4, 0.0, 0.0, 0.0, 0.0, 0.0, 33.0, 0.0, false, "true", 0.0, "Cheese", "Protein,Fats", "France", 5.75m, 25.0, 0.0, 0.0 },
                    { 5, 0.0, 0.0, 0.0, 0.0, 0.0, 1.5, 0.0, true, "true", 0.0, "Pasta", "Carbohydrates", "Italy", 1.99m, 13.0, 0.0, 0.0 },
                    { 6, 0.0, 0.0, 0.0, 0.0, 0.0, 0.20000000000000001, 0.0, true, "true", 0.0, "Tomato", "Vitamins", "Italy", 2.49m, 0.90000000000000002, 0.0, 0.0 },
                    { 7, 0.0, 0.0, 0.0, 0.0, 0.0, 0.5, 0.0, false, "true", 0.0, "Garlic", "Vitamins", "Italy", 1.79m, 6.4000000000000004, 0.0, 0.0 },
                    { 8, 0.0, 0.0, 0.0, 0.0, 0.0, 29.0, 0.0, true, "true", 0.0, "Parmesan", "Protein,Fats", "Italy", 3.99m, 35.799999999999997, 0.0, 0.0 },
                    { 9, 0.0, 0.0, 0.0, 0.0, 0.0, 0.59999999999999998, 0.0, true, "true", 0.0, "Basil", "Vitamins", "Italy", 1.49m, 3.2000000000000002, 0.0, 0.0 },
                    { 10, 0.0, 0.0, 0.0, 0.0, 0.0, 100.0, 0.0, false, "true", 0.0, "Olive Oil", "Fats", "Italy", 4.99m, 0.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Category", "CookTime", "Description", "Difficulty", "IsVegetarian", "Name", "Picture", "PlanId", "PrepTime", "Protein", "Rating", "Servings", "TotalCarbohydrates", "TotalCholesterol", "TotalFat", "TotalFiber", "TotalProtein" },
                values: new object[,]
                {
                    { 9, 210.0, "Breakfast", 10, null, "Easy", false, "Pancakes", "pancakes.jpg", null, 15, 6.0, 4.5, 3, 0.0, 0.0, 8.5, 0.0, 0.0 },
                    { 10, 180.0, "Breakfast", 8, null, "Easy", false, "Omelette", "omelette.jpg", null, 10, 22.0, 4.2000000000000002, 2, 0.0, 0.0, 12.0, 0.0, 0.0 },
                    { 11, 220.0, "Breakfast", 10, null, "Easy", false, "French Toast", "french-toast.jpg", null, 10, 7.0, 4.4000000000000004, 2, 0.0, 0.0, 9.0, 0.0, 0.0 },
                    { 12, 320.0, "Breakfast", 10, null, "Medium", false, "Breakfast Burrito", "breakfast-burrito.jpg", null, 20, 14.0, 4.2999999999999998, 2, 0.0, 0.0, 14.5, 0.0, 0.0 },
                    { 13, 180.0, "Breakfast", 0, null, "Easy", false, "Smoothie Bowl", "smoothie-bowl.jpg", null, 10, 37.0, 4.7999999999999998, 1, 0.0, 0.0, 5.0, 0.0, 0.0 },
                    { 14, 190.0, "Breakfast", 5, null, "Easy", false, "Avocado Toast", "avocado-toast.jpg", null, 5, 4.0, 4.5999999999999996, 1, 0.0, 0.0, 11.0, 0.0, 0.0 },
                    { 15, 160.0, "Breakfast", 0, null, "Easy", false, "Granola Yogurt", "granola-yogurt.jpg", null, 5, 40.0, 4.7000000000000002, 1, 0.0, 0.0, 6.0, 0.0, 0.0 },
                    { 16, 150.0, "Breakfast", 5, null, "Easy", false, "Scrambled Eggs", "scrambled-eggs.jpg", null, 5, 11.0, 4.2999999999999998, 2, 0.0, 0.0, 10.0, 0.0, 0.0 },
                    { 17, 230.0, "Breakfast", 20, null, "Medium", false, "Breakfast Muffins", "breakfast-muffins.jpg", null, 20, 6.0, 4.2000000000000002, 4, 0.0, 0.0, 7.5, 0.0, 0.0 },
                    { 18, 200.0, "Breakfast", 0, null, "Easy", false, "Chia Pudding", "chia-pudding.jpg", null, 10, 6.0, 4.5, 2, 0.0, 0.0, 9.0, 0.0, 0.0 },
                    { 19, 350.0, "Lunch", 10, null, "Easy", false, "Chicken Salad", "chicken-salad.jpg", null, 15, 25.0, 4.2999999999999998, 3, 0.0, 0.0, 15.0, 0.0, 0.0 },
                    { 20, 300.0, "Lunch", 10, null, "Easy", false, "Grilled Cheese Sandwich", "grilled-cheese.jpg", null, 5, 10.0, 4.5999999999999996, 1, 0.0, 0.0, 18.0, 0.0, 0.0 },
                    { 21, 270.0, "Lunch", 5, null, "Easy", false, "Turkey Wrap", "turkey-wrap.jpg", null, 10, 18.0, 4.2000000000000002, 1, 0.0, 0.0, 9.5, 0.0, 0.0 },
                    { 22, 240.0, "Lunch", 0, null, "Easy", false, "Caesar Salad", "caesar-salad.jpg", null, 15, 7.0, 4.0999999999999996, 2, 0.0, 0.0, 14.0, 0.0, 0.0 },
                    { 23, 320.0, "Lunch", 10, null, "Easy", false, "BLT Sandwich", "blt.jpg", null, 10, 12.0, 4.4000000000000004, 1, 0.0, 0.0, 16.0, 0.0, 0.0 },
                    { 24, 210.0, "Lunch", 0, null, "Easy", false, "Veggie Wrap", "veggie-wrap.jpg", null, 10, 6.0, 4.5, 1, 0.0, 0.0, 7.0, 0.0, 0.0 },
                    { 25, 150.0, "Lunch", 20, null, "Easy", false, "Tomato Soup", "tomato-soup.jpg", null, 10, 4.0, 4.2999999999999998, 3, 0.0, 0.0, 5.5, 0.0, 0.0 },
                    { 26, 290.0, "Lunch", 10, null, "Easy", false, "Chicken Wrap", "chicken-wrap.jpg", null, 10, 20.0, 4.4000000000000004, 1, 0.0, 0.0, 11.0, 0.0, 0.0 },
                    { 27, 330.0, "Lunch", 10, null, "Easy", false, "Pasta Salad", "pasta-salad.jpg", null, 15, 9.0, 4.2000000000000002, 3, 0.0, 0.0, 12.5, 0.0, 0.0 },
                    { 28, 260.0, "Lunch", 15, null, "Easy", false, "Quinoa Bowl", "quinoa-bowl.jpg", null, 15, 10.0, 4.7000000000000002, 2, 0.0, 0.0, 8.0, 0.0, 0.0 },
                    { 29, 480.0, "Dinner", 25, null, "Medium", false, "Spaghetti Bolognese", "spaghetti.jpg", null, 20, 22.0, 4.5999999999999996, 4, 0.0, 0.0, 20.0, 0.0, 0.0 },
                    { 30, 420.0, "Dinner", 15, null, "Medium", false, "Grilled Salmon", "salmon.jpg", null, 15, 34.0, 4.7999999999999998, 2, 0.0, 0.0, 18.0, 0.0, 0.0 },
                    { 31, 390.0, "Dinner", 15, null, "Medium", false, "Beef Stir Fry", "beef-stir-fry.jpg", null, 20, 28.0, 4.5, 3, 0.0, 0.0, 16.5, 0.0, 0.0 },
                    { 32, 310.0, "Dinner", 20, null, "Medium", false, "Vegetable Curry", "veg-curry.jpg", null, 20, 9.0, 4.4000000000000004, 4, 0.0, 0.0, 13.0, 0.0, 0.0 },
                    { 33, 550.0, "Dinner", 20, null, "Medium", false, "Chicken Alfredo", "alfredo.jpg", null, 20, 30.0, 4.5999999999999996, 3, 0.0, 0.0, 22.0, 0.0, 0.0 },
                    { 34, 360.0, "Dinner", 10, null, "Medium", false, "Shrimp Tacos", "shrimp-tacos.jpg", null, 15, 20.0, 4.7000000000000002, 3, 0.0, 0.0, 14.0, 0.0, 0.0 },
                    { 35, 280.0, "Dinner", 30, null, "Medium", false, "Stuffed Peppers", "stuffed-peppers.jpg", null, 25, 12.0, 4.2999999999999998, 4, 0.0, 0.0, 10.0, 0.0, 0.0 },
                    { 36, 600.0, "Dinner", 20, null, "Hard", false, "Lamb Chops", "lamb-chops.jpg", null, 20, 35.0, 4.5, 2, 0.0, 0.0, 25.0, 0.0, 0.0 },
                    { 37, 250.0, "Dinner", 20, null, "Easy", false, "Baked Cod", "baked-cod.jpg", null, 10, 28.0, 4.4000000000000004, 2, 0.0, 0.0, 9.0, 0.0, 0.0 },
                    { 38, 410.0, "Dinner", 30, null, "Medium", false, "Mushroom Risotto", "risotto.jpg", null, 15, 10.0, 4.5999999999999996, 3, 0.0, 0.0, 17.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "A balanced weekly meal plan", "Healthy Week" },
                    { 2, "Meals focused on high protein intake", "High Protein" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
