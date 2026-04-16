using MediatR;

namespace Bookly.Application.Features.Commands.Users.UpdateUserRole;
public class UpdateUserRoleCommandResponse
{
    public string Message { get; set; }
    public UpdateUserRoleCommandResponse(string message) => Message = message;
}

