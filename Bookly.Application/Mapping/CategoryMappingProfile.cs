using AutoMapper;
using Bookly.Application.Features.Commands.Category.CreateCategory;
using Bookly.Domain.Entities;

namespace Bookly.Application.Mapping;
public class CategoryMappingProfile : Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();

    }
}
