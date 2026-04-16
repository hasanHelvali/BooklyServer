using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookly.Application.Features.Commands.Users.UpdateUserRole
{
    public class UpdateUserRoleCommandRequest : IRequest<UpdateUserRoleCommandResponse>
    {
        public Guid UserId { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
