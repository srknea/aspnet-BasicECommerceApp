using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicECommerceApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : CustomBaseController
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(string? visitorId, string? userId, CartItemDto cartItemDto)
        {
            var cart = await _cartService.AddProductToCart(visitorId, userId, cartItemDto);
            
            return CreateActionResult(CustomResponseDto<string>.Success(201, cart));
        }

    }
}
