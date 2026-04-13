using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;

namespace Bookly.Application.Features.Commands.Category.DeleteCategory;

internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
{
    private readonly IRepository<Domain.Entities.Category> _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteCategoryCommandHandler(IRepository<Domain.Entities.Category> categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async  Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
         var category = await _categoryRepository.GetById(request.Id.ToString(), true);
        if (category is null)
            throw new BusinessException("Kategori Bulunamadı.");
        _categoryRepository.Remove(category);
        await _unitOfWork.SaveChangesAsync();
        return new DeleteCategoryCommandResponse("Kategori Silme İşlemi Başarılı.");
    }
}
