using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerceApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {
        readonly IMediator _mediator;

        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(IMediator mediator, ICategoryService categoryService, IMapper mapper)
        {
            _mediator = mediator;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());

            return CreateActionResult(CustomResponseDto<GetAllCategoryQueryResponse>.Success(200, response));
        }

        
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<CreateCategoryCommandResponse>.Success(201, response));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        // TODO: Bir kategorinin alt kategorisi varsa silme işlemi yapılamıyor. Bu sorun çözülmeli.
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            await _mediator.Send(removeCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            // 204 : İşlem sonucunda bir data dönmediğimiz, sadece durumun başarılı olduğunu client'a söylemek istediğimiz senaryolarda kullanırız.
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            await _mediator.Send(updateCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
