
using Bookly.Persistence.Context;
using Bookly.Persistence.Seeds;
using Bookly.WebAPI.Configurations;
using Bookly.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace Bookly.WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);

            // Add services to the container.

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            ;

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                db.Database.Migrate();
                await DataSeeder.SeedAsync(scope.ServiceProvider);
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors();//UseHttpsRedirection dan once kullanýlmalýdýr. 
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
