using Bookly.Infrastructure.Options;
using Microsoft.Extensions.Options;
namespace Bookly.WebAPI.OptionsSetup;
public sealed class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
    private const string JwtSettings = nameof(JwtSettings);
    private readonly IConfiguration _configuration;

    public JwtOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(JwtOptions options)
    {
        _configuration.GetSection(JwtSettings).Bind(options);
    }
}
