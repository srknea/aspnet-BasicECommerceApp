using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetByIdProductWithCategoryQueryHandler : IRequestHandler<GetByIdProductWithCategoryQueryRequest, GetByIdProductWithCategoryQueryResponse>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetByIdProductWithCategoryQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<GetByIdProductWithCategoryQueryResponse> Handle(GetByIdProductWithCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            /*
            var product = await _productService.GetByIdProductWithCategory(request.Id);

            var dto = _mapper.Map<SubCategoryDto>(product.SubCategory);
            //var dto = _mapper.Map<CategoryDto>(product.SubCategory.Category);

            return new GetByIdProductWithCategoryQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                SubCategory = _mapper.Map<SubCategoryDto>(product.SubCategory),
                Category = _mapper.Map<CategoryDto>(product.SubCategory.Category)
            };
            */
            return new GetByIdProductWithCategoryQueryResponse();
        }
    }
}

//Category = _mapper.Map<CategoryDto>(productsWithCategories.Category),
//Products = _mapper.Map<List<ProductDto>>(productsWithCategories.Products)