
using CA1_BackEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace CA1_BackEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Skip migrations when swagger CLI is generating (tofile command)
            var isSwaggerCli = args.Length > 0 && args.Contains("tofile");

            // Get connection string - guard against missing config in swagger CLI context
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString) && !isSwaggerCli)
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' is missing. Check appsettings.json or environment variables.");
            }

            // Register the DbContext — reads the connection string from appsettings.json
            // and tells EF Core to use SQL Server
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    options.UseSqlServer(connectionString,
                        sqlOptions => sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(10),
                            errorNumbersToAdd: null));
                }
            });

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
            // Skip this when swagger CLI is generating (tofile command)
            if (!isSwaggerCli)
            {
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
