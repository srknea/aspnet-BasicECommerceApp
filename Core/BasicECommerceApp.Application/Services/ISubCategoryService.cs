using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Domain.Entities;

namespace BasicECommerceApp.Application.Services
{
    public interface ISubCategoryService : IGenericService<SubCategory>
    {
        Task<SubCategory> GetProductsBySubCategoryNameWithCategories(string categoryName);
    }
}
