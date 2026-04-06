using AutoMapper;
using Bookly.Domain.Repositories;
using MediatR;

namespace Bookly.Application.Features.Queries.Product.GetById;
internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
{
    private readonly IRepository<Domain.Entities.Product> _productRepository;
    private readonly IMapper _mapper;
    public GetProductByIdQueryHandler(IRepository<Domain.Entities.Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
    {
       var product =  await _productRepository.GetById(request.Id.ToString(),false);
        if (product is null)
            throw new Exception($"Product not found: {request.Id}");
        return _mapper.Map<GetProductByIdQueryResponse>(product);
    }
}
