using Bookly.Application.Features.Commands.Users.GetAllUsers;
using Bookly.Application.Features.Commands.Users.UpdateUserRole;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
[Authorize(Roles = "Admin")]
public class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator) { }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllUsersQueryRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateUserRole(UpdateUserRoleCommandRequest request, CancellationToken
cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
