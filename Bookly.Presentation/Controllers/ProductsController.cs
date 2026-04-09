using Bookly.Application.Features.Commands.Product.CreateProduct;
using Bookly.Application.Features.Commands.Product.UpdateProduct;
using Bookly.Application.Features.Queries.Product.GetAll;
using Bookly.Application.Features.Queries.Product.GetById;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]

public class ProductsController : ApiController
{
    public ProductsController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
    {
       CreateProductCommandResponse response=await  _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProducts()
    {
        GetAllProductsQueryRequest request = new GetAllProductsQueryRequest();
        List<GetAllProductsQueryResponse> response =  await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet("[action]/{id}")]
    public async Task<IActionResult> GetProductById(Guid id,CancellationToken ct)
    {
        if (string.IsNullOrEmpty(id.ToString())) throw new Exception("Ürün Bulunamadı.");
        var request = new GetProductByIdQueryRequest(id);
        var response = await _mediator.Send(request);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request,CancellationToken cancellationToken)
    {
        UpdateProductCommandResponse response =  await _mediator.Send(request,cancellationToken);
        return Ok(response);
    }


}
