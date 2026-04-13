using Bookly.Application.Features.Commands.Auth.Login;
using Bookly.Application.Features.Commands.Auth.RefreshToken;
using Bookly.Application.Features.Commands.Auth.Register;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;

namespace Bookly.Presentation.Controllers;

public class AuthController : ApiController
{
    public AuthController(IMediator mediator) : base(mediator) { }

    /// <summary>
    /// Yeni Kullanıcı Kaydı Oluştur. 
    /// </summary>
    /// <param name="request" Kayıt Bilgilerini İçeren Request Modeli</param>
    /// <returns>Kayıt İşleminin Sonucunu Döndür.</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        RegisterCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }

    /// <summary>
    /// Kullanıcı girişi yapar ve JWT token döndürür.
    /// </summary>
    /// <param name="request">Email ve şifre bilgilerini içeren istek modeli.</param>
    /// <returns>JWT token ve geçerlilik süresini döndürür.</returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        LoginCommandResponse response = await _mediator.Send(request);
        return Ok(response);
    }


    /// <summary>
    /// Refresh token flow'u şöyle:
    ///1. Access token süresi dolar → frontend 401 alır
    ///2. Frontend, refresh token'ı bu endpoint'e gönderir
    ///3. Backend doğrular, yeni access token + yeni refresh token döner
    ///4. Frontend yeni token'ları kaydeder, orijinal isteği tekrarlar
    ///Refresh token'ı direkt backend'de otomatik yenileyemezsin çünkü backend stateless — her isteği bağımsız değerlendirir.
    ///Frontend'in "token yenile" isteğini açıkça yapması gerekiyor. Bu yüzden ayrı bir endpoint şart.
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
