using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
