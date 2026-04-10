using Bookly.Application.Features.Commands.Category.CreateCategory;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;
public class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request,CancellationToken cancellationToken)
    {
        CreateCategoryCommandResponse response =  await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }
}
