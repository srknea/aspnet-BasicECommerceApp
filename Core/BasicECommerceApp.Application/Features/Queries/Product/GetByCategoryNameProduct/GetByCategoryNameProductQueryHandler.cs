using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetByCategoryNameProductQueryHandler : IRequestHandler<GetByCategoryNameProductQueryRequest, GetByCategoryNameProductQueryResponse>
    {
        /*
        readonly ISubCategoryService _subCategoryService;
        readonly IMapper _mapper;

        public GetByCategoryNameProductQueryHandler(ISubCategoryService subCategoryService, IMapper mapper)
        {
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }
        */

        public async Task<GetByCategoryNameProductQueryResponse> Handle(GetByCategoryNameProductQueryRequest request, CancellationToken cancellationToken)
        {
            /*  
              var productsWithCategories = await _subCategoryService.GetProductsBySubCategoryNameWithCategories(request.SubCategoryName);



              return new GetByCategoryNameProductQueryResponse()
              {
                  Id = productsWithCategories.Id,
                  Name = productsWithCategories.Name,
                  //CategoryId = productsWithCategories.CategoryId,
                  Category = _mapper.Map<CategoryDto>(productsWithCategories.Category),
                  Products = _mapper.Map<List<ProductDto>>(productsWithCategories.Products)
              };
             */
            return new();
        }
    }
}