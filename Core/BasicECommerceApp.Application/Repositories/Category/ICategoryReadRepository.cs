using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories.Category
{
    public interface ICategoryReadRepository : IGenericReadRepository<Domain.Entities.Category>
    {
        Task<Domain.Entities.Category> GetCategoryByNameWithProducts(string categoryName);
        Task<List<Domain.Entities.Category>> GetAllCategoriesWithSubCategories();
    }
}
