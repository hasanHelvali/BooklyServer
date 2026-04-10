using AutoMapper;
using Bookly.Application.Features.Commands.Category.CreateCategory;
using Bookly.Domain.Entities;

namespace Bookly.Application.Mapping;
public class CategoryMappingProfile : Profile
{
    protected CategoryMappingProfile()
    {
        CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
    }
}
