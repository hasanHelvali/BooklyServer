using AutoMapper;
using Bookly.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bookly.Application.Features.Queries.Product.GetAll;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsQueryResponse>>
{
    private readonly IRepository<Domain.Entities.Product> _productRepository;
    private readonly IMapper _mapper;
    public GetAllProductsQueryHandler(IRepository<Domain.Entities.Product> productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products  = await _productRepository.GetAll(false).ToListAsync();
        //return products.Select(p => new GetAllProductQueryResponse
        //{
        //    Id = p.ID,
        //    Name = p.Name,
        //    Author = p.Author,
        //    Price = p.Price,
        //    Stock = p.Stock,
        //    Category = p.Category,
        //    ImageUrl = p.ImageUrl,
        //    IsActive = p.IsActive
        //}).ToList();

        return _mapper.Map<List<GetAllProductsQueryResponse>>(products);

    }

}
