using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryService _categoryService;

        public GetAllCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetAllCategoriesWithSubCategories();

            return new GetAllCategoryQueryResponse()
            {
                Categories = categories
            };
        }
    }
}