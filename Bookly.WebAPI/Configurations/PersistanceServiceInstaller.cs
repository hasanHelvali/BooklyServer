using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using Bookly.Persistence.Context;
using Bookly.Persistence.Options;
using Bookly.Persistence.Repositories;
using Bookly.Persistence.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Bookly.WebAPI.Configurations;

public class PersistanceServiceInstaller : IServiceInstaller
{
    private const string SectionName = "SqlServer";
    public void Install(IServiceCollection services, IConfiguration configuration)
    {

        var dbOptions = configuration
            .GetSection(DatabaseOptions.SectionName)
                .Get<DatabaseOptions>()!;//Konfigurasyonu ceker. 

        services.Configure<DatabaseOptions>(
            configuration.GetSection(DatabaseOptions.SectionName));//DI Kaydı icindir. DatabaseOptions basjka yerde injet edilmeyecekse silinebilir.

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(dbOptions.SqlServer));

        //string connectionString = configuration.GetConnectionString(SectionName);
     //   services.AddDbContext<ApplicationDbContext>(options =>
     //options.UseSqlServer(connectionString));
        
        services.AddIdentity<User, AppRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
        })
  .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
