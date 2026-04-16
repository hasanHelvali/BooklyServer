using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Enums;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;
using Siparis = Bookly.Domain.Entities.Order;
namespace Bookly.Application.Features.Commands.Order.UpdateOrderStatus;

public class UpdateOrderStatusCommandHandler : IRequestHandler<UpdateOrderStatusCommandRequest, UpdateOrderStatusCommandResponse>
{
    private readonly IRepository<Siparis> _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderStatusCommandHandler(IRepository<Siparis> orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateOrderStatusCommandResponse> Handle(UpdateOrderStatusCommandRequest request, CancellationToken
cancellationToken)
    {
        var order = await _orderRepository.GetById(request.OrderId.ToString(), true);
        if (order is null)
            throw new BusinessException("Sipariş bulunamadı.");

        if (!Enum.TryParse<OrderStatus>(request.Status, out var status))
            throw new BusinessException("Geçersiz sipariş durumu.");

        order.Status = status;
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateOrderStatusCommandResponse("Sipariş durumu güncellendi.");
    }
}
