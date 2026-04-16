namespace Bookly.Application.Features.Commands.Order.CreateOrder;
public class CreateOrderCommandResponse
{
    public Guid OrderId { get; set; }
    public string Message { get; set; } = string.Empty;
}
