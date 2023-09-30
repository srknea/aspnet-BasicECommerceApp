using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface IProductService : IGenericService<Product>
    {
        //Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdProductWithCategory (string id);
    }
}
