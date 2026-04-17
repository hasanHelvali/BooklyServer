using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Entities;
using Bookly.Domain.Enums;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Siparis = Bookly.Domain.Entities.Order;
using Urun = Bookly.Domain.Entities.Product;
namespace Bookly.Application.Features.Commands.Order.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IRepository<Siparis> _orderRepository;
    private readonly IRepository<Urun> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateOrderCommandHandler(
        IRepository<Siparis> orderRepository,
        IRepository<Urun> productRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
    {
        var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)
            ?? _httpContextAccessor.HttpContext?.User.FindFirst("sub");

        if (userIdClaim is null)
            throw new BusinessException("Kullanıcı kimliği doğrulanamadı.");

        var userId = Guid.Parse(userIdClaim.Value);

        var order = new Siparis
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            Status = OrderStatus.Pending,
            OrderItems = new List<OrderItem>()
        };

        decimal total = 0;

        foreach (var item in request.Items)
        {
            var product = await _productRepository.GetById(item.ProductId.ToString(), false);
            if (product is null)
                throw new BusinessException($"Ürün bulunamadı: {item.ProductId}");

            if (product.Stock < item.Quantity)
                throw new BusinessException($"'{product.Name}' için yeterli stok yok.");

            order.OrderItems.Add(new OrderItem
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = product.Price
            });
            product.Stock -= item.Quantity;
            total += product.Price * item.Quantity;
        }

        order.TotalAmount = total;

        await _orderRepository.AddAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateOrderCommandResponse
        {
            OrderId = order.ID,
            Message = "Sipariş başarıyla oluşturuldu."
        };
    }
}
