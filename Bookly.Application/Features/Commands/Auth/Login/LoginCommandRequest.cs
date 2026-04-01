using MediatR;

namespace Bookly.Application.Features.Commands.Auth.Login
{
    public sealed record  LoginCommandRequest(string Email, string Password):IRequest<LoginCommandResponse>;
}
