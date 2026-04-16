using MediatR;

namespace Bookly.Application.Features.Commands.Order.UpdateOrderStatus;

public class UpdateOrderStatusCommandRequest : IRequest<UpdateOrderStatusCommandResponse>
{
    public Guid OrderId { get; set; }
    public string Status { get; set; } = string.Empty;
}
