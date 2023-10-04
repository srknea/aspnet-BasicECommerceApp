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
            
            var product = await _productService.GetByIdProductWithCategory(request.Id);

            var dto = _mapper.Map<CategoryDto>(product.Category); //

            return new GetByIdProductWithCategoryQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                Category = _mapper.Map<CategoryDto>(product.Category) //
            };
        }
    }
}