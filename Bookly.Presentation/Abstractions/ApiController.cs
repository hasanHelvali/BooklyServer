using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Abstractions;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController:ControllerBase
{
    protected readonly IMediator _mediator;

    protected ApiController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
