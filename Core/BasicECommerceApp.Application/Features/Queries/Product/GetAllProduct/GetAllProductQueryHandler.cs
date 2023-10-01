using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllSubCategory;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllSubCategory
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync();

            return new GetAllProductQueryResponse()
            {
                Products = _mapper.Map<List<ProductDto>>(products)
            };
        }
    }
}