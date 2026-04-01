using Bookly.Domain.Interfaces;
using Bookly.Infrastructure.Options;
using Bookly.Infrastructure.Services;
using Bookly.WebAPI.OptionsSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Bookly.WebAPI.Configurations;
public class InfrastructureServiceInstaller : IServiceInstaller
{
    public void Install(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddScoped<IJwtProvider, JwtProvider>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();
        /*
           İlk çağrılma anı: AddJwtBearer() ile kaydedilen JWT middleware ilk kez JwtBearerOptions'a ihtiyaç duyduğunda — yani
  uygulama başlayıp ilk request geldiğinde veya middleware pipeline kurulurken. O noktada ASP.NET kayıtlı tüm
  IPostConfigureOptions<JwtBearerOptions> implementasyonlarını buluyor, JwtBearerOptionsSetup.PostConfigure() çalışıyor.

  ▎ Önce AddJwtBearer() çağrısı. Sonra sistemdeki IPostConfigureOptions<JwtBearerOptions>'lar taranıyor,
  JwtBearerOptionsSetup çağrılıyor. İçeride IOptions<JwtOptions> talep ediliyor, JwtOptionsSetup çalışıyor,
  konfigürasyonlar modele çekiliyor. PostConfigure'da ise token doğrulama parametreleri ayarlanıyor. Gerçek doğrulama
  request gelince JwtBearerHandler'da yapılıyor. [Authorize] attribute varsa bu mekanizma devreye giriyor.
         */

        services.ConfigureOptions<JwtOptionsSetup>();
        services.ConfigureOptions<JwtBearerOptionsSetup>();
    }

}
