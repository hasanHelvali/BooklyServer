using AutoMapper;
using Bookly.Application.Features.Commands.Auth.Register;
using Bookly.Application.Features.Queries.Product.GetAll;
using Bookly.Application.Features.Queries.Product.GetById;
using Bookly.Domain.Entities;

namespace Bookly.Application.Mapping;

public class AuthMappingProfile : Profile
{
    public AuthMappingProfile()
    {
        CreateMap<RegisterCommandRequest, User>().ForMember(dest => dest.UserName, targ => targ.MapFrom(src => src.Email));
        /* UserName ile Email property isimleri farklı olduğu için AutoMapper otomatik eşleyemiyor. ForMember ile "bu alanı
      şuradan al" diyorsun:

      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))

      Yani RegisterCommandRequest.Email → User.UserName olarak map edilsin demek. İsimler aynı olsaydı yazmana gerek yoktu,
      AutoMapper otomatik eşlerdi.
        */

        CreateMap<Product, GetAllProductsQueryResponse>().ReverseMap();
        CreateMap<Product, GetProductByIdQueryResponse>().ReverseMap();
    }
}
