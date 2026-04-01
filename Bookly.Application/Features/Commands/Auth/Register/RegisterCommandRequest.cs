using MediatR;

namespace Bookly.Application.Features.Commands.Auth.Register;

public sealed record  RegisterCommandRequest(string FirstName,string LastName,string Email,string Password):IRequest<RegisterCommandResponse>;
