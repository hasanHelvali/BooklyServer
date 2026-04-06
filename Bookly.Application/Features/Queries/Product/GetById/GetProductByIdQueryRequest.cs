using MediatR;

namespace Bookly.Application.Features.Queries.Product.GetById;
public  record GetProductByIdQueryRequest(Guid Id):IRequest<GetProductByIdQueryResponse>;
