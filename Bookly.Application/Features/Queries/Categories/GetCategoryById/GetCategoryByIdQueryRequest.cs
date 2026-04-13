using MediatR;

namespace Bookly.Application.Features.Queries.Categories.GetCategoryById;
public record GetCategoryByIdQueryRequest(Guid Id) : IRequest<GetCategoryByIdQueryResponse>;
