using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using MediatR;

namespace Bookly.Application.Features.Queries.Categories.GetCategoryById;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
{
    private readonly IRepository<Category> _repository;

    public GetCategoryByIdQueryHandler(IRepository<Category> repository)
    {
        _repository = repository;
    }

    public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken
cancellationToken)
    {
        var category = await _repository.GetById(request.Id.ToString());
        if (category is null)
            throw new BusinessException("Kategori bulunamadı.");

        return new GetCategoryByIdQueryResponse(category.ID, category.Name);
    }
}
