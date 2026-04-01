using Bookly.WebAPI.Middlewares;
namespace Bookly.WebAPI.Configurations;

public class PresentationServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddCors(options => options.AddDefaultPolicy(options =>
        {
            options.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(options => true);
        }));

        services.AddControllers()
            .AddApplicationPart(typeof(Bookly.Presentation.AssemblyReference).Assembly);
        // Lsearn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }
}
