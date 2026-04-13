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
        if (user is null)
            throw new BusinessException("Email veya şifre hatalı.");
        var roles = await _userManager.GetRolesAsync(user);

        bool isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!isPasswordValid)
            throw new BusinessException("Email veya şifre hatalı.");
        var refreshToken = _jwtProvider.GenerateRefreshToken();
        string token = _jwtProvider.GenerateToken(user,roles);
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
        await _userManager.UpdateAsync(user);
        return new LoginCommandResponse
        {
            Token = token,
            RefreshToken=refreshToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(60)
        };
    }
}
