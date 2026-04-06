using Bookly.Domain.Entities;
using Bookly.Domain.Repositories;
using Bookly.Domain.UnitOfWorks;
using MediatR;

namespace Bookly.Application.Features.Commands.Product.CreateProduct;

internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private IRepository<Domain.Entities.Product> _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProductCommandHandler(IMediator mediator, IUnitOfWork unitOfWork, IRepository<Domain.Entities.Product> productRepository)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product=new Domain.Entities.Product()
        {
            Name = request.Name,
            Author = request.Author,
            Price = request.Price,
            Stock = request.Stock,
            Category = request.Category,
            ImageUrl = request.ImageUrl,
            IsActive = true
        };

        await _productRepository.AddAsync(product, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateProductCommandResponse
        {
            Id = Guid.NewGuid(),
            Message = "Ürün Başarıyla Eklendi."
        };
    }
}
