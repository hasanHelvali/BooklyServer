using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Application.Features.Queries.Product.GetBestSelling;
public class GetBestSellingProductsQueryHandler : IRequestHandler<GetBestSellingProductsQueryRequest,
  List<GetBestSellingProductsQueryResponse>>
{
    private readonly IRepository<OrderItem> _orderItemRepository;

    public GetBestSellingProductsQueryHandler(IRepository<OrderItem> orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task<List<GetBestSellingProductsQueryResponse>> Handle(GetBestSellingProductsQueryRequest request,
CancellationToken cancellationToken)
    {
        return await _orderItemRepository.GetAll(false)
      .Include(oi => oi.Product)
      .GroupBy(oi => oi.ProductId)
      .Select(g => new GetBestSellingProductsQueryResponse
      {
          Id = g.Key,
          Name = g.First().Product.Name,
          Author = g.First().Product.Author,
          Price = g.First().Product.Price,
          ImageUrl = g.First().Product.ImageUrl,
          TotalSold = g.Sum(oi => oi.Quantity)
      })
      .OrderByDescending(x => x.TotalSold)
      .Take(request.Count)
      .ToListAsync(cancellationToken);
    }
}
