
using Bookly.Application;
using Bookly.Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bookly.WebAPI.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(AssemblyReference).Assembly));

            services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);
            services.AddAutoMapper(cfg => cfg.AddMaps(typeof(AssemblyReference).Assembly));
        }
    }
}
