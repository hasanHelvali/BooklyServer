
using Bookly.WebAPI.Configurations;
using Bookly.WebAPI.Middlewares;
using Scalar.AspNetCore;

namespace Bookly.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.InstallServices(
    builder.Configuration, typeof(IServiceInstaller).Assembly);

            // Add services to the container.

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            ;

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseCors();//UseHttpsRedirection dan once kullanýlmalýdýr. 
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
