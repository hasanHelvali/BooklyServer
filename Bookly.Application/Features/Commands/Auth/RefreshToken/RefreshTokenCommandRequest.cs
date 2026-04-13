using MediatR;

namespace Bookly.Application.Features.Commands.Auth.RefreshToken;

public record RefreshTokenCommandRequest(string RefreshToken) : IRequest<RefreshTokenCommandResponse>;
