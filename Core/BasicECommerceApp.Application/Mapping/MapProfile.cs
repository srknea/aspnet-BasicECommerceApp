using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.DTOs.Auth;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Domain.Entities.Auth;

namespace BasicECommerceApp.Application.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUserDto, AppUser>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryWithChildrenDto>().ReverseMap();
            CreateMap<Category, CategoryWithSubCategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, CategoryWithSubCategoryDto>().ReverseMap();
        }
    }
}
