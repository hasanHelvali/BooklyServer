using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Entities;
using Bookly.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Bookly.Application.Features.Commands.Auth.Login;
public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(UserManager<User> userManager, IJwtProvider jwtProvider)
    {
        _userManager = userManager;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByEmailAsync(request.Email);
        var roles = await _userManager.GetRolesAsync(user);
        if (user is null)
            throw new BusinessException("Email veya şifre hatalı.");

        bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
            throw new BusinessException("Email veya şifre hatalı.");

        string token = _jwtProvider.GenerateToken(user,roles);

        return new LoginCommandResponse
        {
            Token = token,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }
}
