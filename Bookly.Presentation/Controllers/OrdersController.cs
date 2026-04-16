using Bookly.Application.Features.Commands.Order.CreateOrder;
using Bookly.Application.Features.Commands.Order.UpdateOrderStatus;
using Bookly.Application.Features.Queries.Orders.GetAllOrders;
using Bookly.Application.Features.Queries.Orders.GetMyOrders;
using Bookly.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookly.Presentation.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
public class OrdersController : ApiController
{
    public OrdersController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateOrder(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> GetMyOrders(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetMyOrdersQueryRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetAllOrdersQueryRequest(), cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateOrderStatus(UpdateOrderStatusCommandRequest request, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
