using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Application.Features.Queries.Orders.GetAllOrders;
public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, List<GetAllOrdersQueryResponse>>
{
    private readonly IRepository<Order> _orderRepository;

    public GetAllOrdersQueryHandler(IRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<List<GetAllOrdersQueryResponse>> Handle(GetAllOrdersQueryRequest request, CancellationToken
cancellationToken)
    {
        var orders = await _orderRepository.GetAll(false)
            .Include(o => o.User)
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync(cancellationToken);

        return orders.Select(o => new GetAllOrdersQueryResponse
        {
            Id = o.ID,
            CustomerName = $"{o.User.FirstName} {o.User.LastName}",
            CustomerEmail = o.User.Email!,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Status = o.Status.ToString(),
            ItemCount = o.OrderItems.Count
        }).ToList();
    }
}
