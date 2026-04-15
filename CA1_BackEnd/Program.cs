
using CA1_BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace CA1_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register the DbContext — reads the connection string from appsettings.json
            // and tells EF Core to use SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            if (builder.Environment.IsDevelopment())
            {
                builder.WebHost.UseUrls("http://0.0.0.0:5228");
            }
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Apply any pending migrations and create the database automatically on startup
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Database migration failed: {ex.Message}");
                    throw;
                }
            }

            // Enable Swagger in all environments
            app.UseSwagger();
            app.UseSwaggerUI();

            // Redirect root URL to Swagger
            app.MapGet("/", () => Results.Redirect("/swagger"));

          //  app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
