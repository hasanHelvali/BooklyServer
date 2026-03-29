
namespace Bookly.WebAPI.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(typeof(AssemblyReference).Assembly);

            //    services.AddTransient(typeof(IPipelineBehavior<,>), (typeof(ValidationBehavior<,>)));

            //    services.AddValidatorsFromAssembly(typeof(AssemblyReference).Assembly);

            //throw new NotImplementedException();
        }
    }
}
