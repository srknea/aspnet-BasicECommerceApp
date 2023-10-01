using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Exceptions;
using BasicECommerceApp.Application.Features.Commands.Product.CreateProduct;
using BasicECommerceApp.Application.Features.Queries.Product.GetAllProduct;
using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Persistance.Repositories.Product;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);

            return CreateActionResult(CustomResponseDto<GetByIdProductQueryResponse>.Success(200, response));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdProductWithCategory([FromRoute] GetByIdProductWithCategoryQueryRequest getByIdProductWithCategoryQueryRequest)
        {
            GetByIdProductWithCategoryQueryResponse response = await _mediator.Send(getByIdProductWithCategoryQueryRequest);

            return CreateActionResult(CustomResponseDto<GetByIdProductWithCategoryQueryResponse>.Success(200, response));
        }

        [HttpGet("{SubCategoryName}")]
        public async Task<IActionResult> GetProductsBySubCategoryNameWithCategories([FromRoute] GetByCategoryNameProductQueryRequest getByCategoryNameProductQueryRequest)
        {
            GetByCategoryNameProductQueryResponse response = await _mediator.Send(getByCategoryNameProductQueryRequest);

            return CreateActionResult(CustomResponseDto<GetByCategoryNameProductQueryResponse>.Success(200, response));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

            return CreateActionResult(CustomResponseDto<CreateProductCommandResponse>.Success(201, response));
            // 201 : Oluşturuldu anlamında kullanılır. İşlem başarılı ise 201 döndürülebilir.
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            await _mediator.Send(removeProductCommandRequest);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            // 204 : İşlem sonucunda bir data dönmediğimiz, sadece durumun başarılı olduğunu client'a söylemek istediğimiz senaryolarda kullanırız.
        }
    }
}
