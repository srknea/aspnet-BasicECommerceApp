using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetByCategoryNameProductQueryHandler : IRequestHandler<GetByCategoryNameProductQueryRequest, GetByCategoryNameProductQueryResponse>
    {
        
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;

        public GetByCategoryNameProductQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<GetByCategoryNameProductQueryResponse> Handle(GetByCategoryNameProductQueryRequest request, CancellationToken cancellationToken)
        {
              var productsWithCategories = await _categoryService.GetCategoryByNameWithProducts(request.SubCategoryName);

              return new GetByCategoryNameProductQueryResponse()
              {
                  Id = productsWithCategories.Id,
                  Name = productsWithCategories.Name,
                  Products = _mapper.Map<List<ProductDto>>(productsWithCategories.Products)
              };
        }
    }
}