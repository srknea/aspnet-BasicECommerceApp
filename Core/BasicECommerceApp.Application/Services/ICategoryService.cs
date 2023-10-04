using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface ICategoryService : IGenericService<Category>
    {
        //Task<List<Category>> GetAllCategoriesWithSubCategories();

        Task<List<Category>> GetAllCategoriesWithSubCategories();
    }
}
