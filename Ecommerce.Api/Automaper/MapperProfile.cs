using AutoMapper;
using Ecommerce.Entities.Models;
using Ecommerce.Shared;

namespace Ecommerce.Api;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Product, ProductToAddDto>().ReverseMap();
    }
}
