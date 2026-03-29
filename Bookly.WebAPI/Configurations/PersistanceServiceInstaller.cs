using Bookly.Domain.Entities;
using Bookly.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bookly.WebAPI.Configurations;

public class PersistanceServiceInstaller:IServiceInstaller
{
    private const string SectionName = "SqlServer";
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString(SectionName);

        services.AddDbContext<ApplicationDbContext>(options =>
     options.UseSqlServer(connectionString));
        services.AddIdentity<User, AppRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();
        
        //services.AddAutoMapper(typeof(AssemblyReference).Assembly);
    }
}
