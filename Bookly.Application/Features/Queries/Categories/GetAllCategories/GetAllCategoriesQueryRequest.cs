using Bookly.Application.Features.Queries.Product.GetAll;
using MediatR;

namespace Bookly.Application.Features.Queries.Categories.GetAllCategories;

public record GetAllCategoriesQueryRequest:IRequest<List<GetAllCategoriesQueryResponse>>;
