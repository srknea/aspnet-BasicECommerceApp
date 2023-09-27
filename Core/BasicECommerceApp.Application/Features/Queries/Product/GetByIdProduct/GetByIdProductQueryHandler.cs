using BasicECommerceApp.Application.Services;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    /* IRequestHandler<TRequest, TResponse> arayüzünü implemente ederek GetByIdProductQueryRequest
    sınıfının request sınıfı olduğunu ve GetByIdProductQueryResponse sınıfının response sınıfı olduğunu belirtiyoruz.*/
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        readonly IProductService _productService;

        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetByIdAsync(request.Id);
          
            return new GetByIdProductQueryResponse()
            {
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price
            };
        }

    }
}