using MediatR;

namespace Bookly.Application.Features.Queries.Product.GetBestSelling;

public class GetBestSellingProductsQueryRequest : IRequest<List<GetBestSellingProductsQueryResponse>>
{
    public int Count { get; set; } = 1;
}
