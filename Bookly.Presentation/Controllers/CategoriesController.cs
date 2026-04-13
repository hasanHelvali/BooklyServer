using Bookly.Application.Features.Commands.Category.CreateCategory;
using Bookly.Application.Features.Commands.Category.DeleteCategory;
using Bookly.Application.Features.Commands.Category.UpdateCategory;
using Bookly.Application.Features.Queries.Categories.GetAllCategories;
using Bookly.Application.Features.Queries.Categories.GetCategoryById;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;
public class CategoriesController : ApiController
{
    public CategoriesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllCategories( CancellationToken cancellationToken)
    {
        List<GetAllCategoriesQueryResponse> response = await _mediator.Send(new GetAllCategoriesQueryRequest(), cancellationToken);
        return Ok(response);
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request,CancellationToken cancellationToken)
    {
        CreateCategoryCommandResponse response =  await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }


    [HttpDelete("[action]/{id}")]
    public async Task<IActionResult> DeleteCategoryById(Guid Id, CancellationToken cancellationToken)
    {
        var request = new DeleteCategoryCommandRequest(Id);
        DeleteCategoryCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetCategoryByIdQueryRequest(id), cancellationToken);
        return Ok(response);
    }
}
