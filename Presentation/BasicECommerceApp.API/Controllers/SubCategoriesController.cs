using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
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
    }
}
