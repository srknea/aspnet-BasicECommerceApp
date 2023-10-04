using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            /*
            var categories = await _categoryService.GetAllCategoriesWithSubCategories();

            var dto = _mapper.Map<List<CategoryWithSubCategoryDto>>(categories);

            return new GetAllCategoryQueryResponse()
            {
                Categories = dto
            };
            */
            return new();
        }
    }
}