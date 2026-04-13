namespace Bookly.Application.Features.Commands.Auth.RefreshToken;

public record RefreshTokenCommandResponse(string Token, string RefreshToken, DateTime ExpiresAt);
