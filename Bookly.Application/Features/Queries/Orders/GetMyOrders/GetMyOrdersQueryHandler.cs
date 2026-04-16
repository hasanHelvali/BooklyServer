using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Bookly.Application.Features.Queries.Orders.GetMyOrders;
public class GetMyOrdersQueryHandler : IRequestHandler<GetMyOrdersQueryRequest, List<GetMyOrdersQueryResponse>>
{
    private readonly IRepository<Order> _orderRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GetMyOrdersQueryHandler(IRepository<Order> orderRepository, IHttpContextAccessor httpContextAccessor)
    {
        _orderRepository = orderRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<List<GetMyOrdersQueryResponse>> Handle(GetMyOrdersQueryRequest request, CancellationToken
cancellationToken)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)
            ?? _httpContextAccessor.HttpContext?.User.FindFirst("sub");

        if (userIdClaim is null)
            throw new UnauthorizedAccessException("Kullanıcı kimliği doğrulanamadı.");

        var userId = Guid.Parse(userIdClaim.Value);

        var orders = await _orderRepository.GetAll(false)
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync(cancellationToken);

        return orders.Select(o => new GetMyOrdersQueryResponse
        {
            Id = o.ID,
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Status = o.Status.ToString(),
            Items = o.OrderItems.Select(oi => new GetMyOrdersItemDto
            {
                ProductName = oi.Product.Name,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice
            }).ToList()
        }).ToList();
    }
}
