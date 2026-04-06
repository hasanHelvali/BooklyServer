using MediatR;

namespace Bookly.Application.Features.Queries.Product.GetAll;
public record GetAllProductsQueryRequest():IRequest<List<GetAllProductsQueryResponse>>;
