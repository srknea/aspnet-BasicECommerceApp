using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface ICartService : IGenericService<Cart>
    {
        Task<string> AddProductToCart(string visitorId, string userName, CartItemDto cartDto);
    }
}
