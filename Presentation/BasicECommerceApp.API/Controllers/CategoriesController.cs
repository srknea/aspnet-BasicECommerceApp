using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct;
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

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCategoryQueryResponse response = await _mediator.Send(new GetAllCategoryQueryRequest());

            return CreateActionResult(CustomResponseDto<GetAllCategoryQueryResponse>.Success(200, response));
        }
    }
}
