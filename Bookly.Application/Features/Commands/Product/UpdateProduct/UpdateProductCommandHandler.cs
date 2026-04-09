using AutoMapper;
using Bookly.Application.Common.Exceptions;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;

namespace Bookly.Application.Features.Commands.Product.UpdateProduct;
internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    private readonly IRepository<Domain.Entities.Product> _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IRepository<Domain.Entities.Product> repository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetById(request.Id.ToString(), true);
        if (product is null)
            throw new BusinessException("Ürün Bulunamadı. Güncelleme İşlemi Başarısız.");

        _mapper.Map(request, product);
        await _unitOfWork.SaveChangesAsync();
        return new UpdateProductCommandResponse() { Message="Üürn Başarıyla Güncellendi."};
    }
}
