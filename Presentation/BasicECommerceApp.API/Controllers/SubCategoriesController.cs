using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllSubCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerceApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubCategoriesController : CustomBaseController
    {
        readonly IMediator _mediator;

        public SubCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateSubCategoryCommandRequest createSubCategoryCommandRequest)
        {
            CreateSubCategoryCommandResponse response = await _mediator.Send(createSubCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<CreateSubCategoryCommandResponse>.Success(201, response));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveSubCategoryCommandRequest removeSubCategoryCommandRequest)
        {
            await _mediator.Send(removeSubCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            // 204 : İşlem sonucunda bir data dönmediğimiz, sadece durumun başarılı olduğunu client'a söylemek istediğimiz senaryolarda kullanırız.
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubCategoryCommandRequest updateSubCategoryCommandRequest)
        {
            await _mediator.Send(updateSubCategoryCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            GetAllSubCategoryQueryResponse response = await _mediator.Send(new GetAllSubCategoryQueryRequest());

            return CreateActionResult(CustomResponseDto<GetAllSubCategoryQueryResponse>.Success(200, response));
        }
    }
}