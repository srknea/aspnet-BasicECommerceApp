using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;

namespace BasicECommerceApp.Application.Features.Queries.Product.GetAllSubCategory
{
    public class GetAllSubCategoryQueryHandler : IRequestHandler<GetAllSubCategoryQueryRequest, GetAllSubCategoryQueryResponse>
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        public GetAllSubCategoryQueryHandler(ISubCategoryService subCategoryService, IMapper mapper)
        {
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }

        public async Task<GetAllSubCategoryQueryResponse> Handle(GetAllSubCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _subCategoryService.GetAllAsync();

            return new GetAllSubCategoryQueryResponse()
            {
                SubCategories = _mapper.Map<List<SubCategoryDto>>(categories)
            };
        }
    }
}