namespace Bookly.Application.Features.Commands.Order.UpdateOrderStatus;
public class UpdateOrderStatusCommandResponse
{
    public string Message { get; set; }
    public UpdateOrderStatusCommandResponse(string message) => Message = message;
}
