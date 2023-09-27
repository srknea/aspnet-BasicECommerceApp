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
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly private IProductService _productService;

        public ProductsController(IProductService productService, IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            
            return Ok(response);
        }
    }
}
