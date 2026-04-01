namespace Bookly.Application.Features.Commands.Auth.Login;
public class LoginCommandResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
}
