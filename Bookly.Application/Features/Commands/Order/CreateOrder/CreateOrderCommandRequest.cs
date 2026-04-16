using MediatR;

namespace Bookly.Application.Features.Commands.Order.CreateOrder;
public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
{
    public List<CreateOrderItemDto> Items { get; set; } = new();
}

public class CreateOrderItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
