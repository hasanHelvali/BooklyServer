using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;
using System.Runtime.CompilerServices;

namespace Bookly.Application.Features.Commands.Product.DeleteProductById;
public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommandRequest, DeleteProductByIdCommandResponse>
{
    private readonly IRepository<Domain.Entities.Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteProductByIdCommandHandler(IRepository<Domain.Entities.Product> productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async  Task<DeleteProductByIdCommandResponse> Handle(DeleteProductByIdCommandRequest request, CancellationToken cancellationToken)
    {
        var product =  await _productRepository.GetById(request.Id.ToString());
        if (product is null)
            throw new BusinessException("Ürün Veritabanında Bulunamadı.");
        await _productRepository.RemoveById(request.Id.ToString());
        await _unitOfWork.SaveChangesAsync();
        return new DeleteProductByIdCommandResponse("Silme İşlemi Başarılı.");
    }
}
