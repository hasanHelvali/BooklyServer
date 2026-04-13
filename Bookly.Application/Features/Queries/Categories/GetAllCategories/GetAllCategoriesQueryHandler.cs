using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using MediatR;

namespace Bookly.Application.Features.Queries.Categories.GetAllCategories;

internal class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;

    public GetAllCategoriesQueryHandler(IRepository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
    {
        var categories =  _categoryRepository.GetAll(false).Select(c=>new GetAllCategoriesQueryResponse (c.ID,c.Name)).ToList();
        return categories;
    }
}
