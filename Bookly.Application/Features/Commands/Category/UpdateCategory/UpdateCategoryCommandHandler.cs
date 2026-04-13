using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;
using Kategori = Bookly.Domain.Entities.Category;

namespace Bookly.Application.Features.Commands.Category.UpdateCategory;
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    private readonly IRepository<Kategori> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IRepository<Kategori> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken
cancellationToken)
    {
        var category = await _repository.GetById(request.Id.ToString(), true);
        if (category is null)
            throw new BusinessException("Kategori bulunamadı.");

        category.Name = request.Name;
        _repository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return new UpdateCategoryCommandResponse("Kategori güncellendi.");
    }
}
