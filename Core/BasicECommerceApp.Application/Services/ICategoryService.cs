using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category> GetCategoryByNameWithProducts(string categoryName);
        Task<List<Category>> GetAllCategoriesWithSubCategories();
    }
}
