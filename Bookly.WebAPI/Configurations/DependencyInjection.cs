using System.Reflection;

namespace Bookly.WebAPI.Configurations
{
    /*
      Assembly'yi tarayıp IServiceInstaller interface'ini implemente eden tüm class'ları buluyor, her birinin Install() metodunu
  çağırıyor.

  Yani sen her katmana bir ServiceInstaller yazıyorsun, Program.cs'de tek satırla hepsini çalıştırıyorsun. Yeni bir katman
  eklenince Program.cs'e dokunmana gerek yok — sadece yeni installer'ı yaz, otomatik bulunuyor.
    */
    public static class DependencyInjection
    {
        public static IServiceCollection InstallServices(
            this IServiceCollection services,
            IConfiguration configuration,
            params Assembly[] assemblies)
        {
            IEnumerable<IServiceInstaller> serviceInstallers = assemblies
                .SelectMany(a => a.DefinedTypes)
                .Where(IsAssignableToType<IServiceInstaller>)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>();

            foreach (IServiceInstaller serviceInstaller in serviceInstallers)
            {
                serviceInstaller.Install(services, configuration);
            }

            return services;

            static bool IsAssignableToType<T>(TypeInfo typeInfo) =>
                typeof(T).IsAssignableFrom(typeInfo) &&
                !typeInfo.IsInterface &&
                !typeInfo.IsAbstract;
        }
    }
}
