using AutoMapper;
using Bookly.Application.Features.Commands.Product.UpdateProduct;
using Bookly.Application.Features.Queries.Product.GetAll;
using Bookly.Application.Features.Queries.Product.GetById;
using Bookly.Domain.Entities;

namespace Bookly.Application.Mapping;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, GetAllProductsQueryResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<Product, GetProductByIdQueryResponse>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        /*
         AutoMapper'a şunu söylüyor: "response'taki CategoryName alanını, product.Category.Name'den al."

  Normalde AutoMapper isimleri eşleştirirken convention kullanır — Product.Name → GetAllProductsQueryResponse.Name otomatik çalışır
   çünkü isimler aynı. Ama CategoryName ile Category.Name arasında bu bağı otomatik kuramaz, o yüzden manuel olarak belirtiyoruz.

         */
        CreateMap<UpdateProductCommandRequest, Domain.Entities.Product>();

    }
}
