using Bookly.Application.Features.Commands.Auth.Login;
using Bookly.Application.Features.Commands.Auth.Register;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
}
