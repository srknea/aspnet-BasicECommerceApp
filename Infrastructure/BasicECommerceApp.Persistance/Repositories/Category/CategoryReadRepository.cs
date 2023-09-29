using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Repositories.Category
{
    public class CategoryReadRepository : GenericReadRepository<Domain.Entities.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(BasicECommerceAppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Domain.Entities.Category>> GetAllCategoriesWithSubCategories()
        {
            return await _context.Categories.Include(x => x.SubCategories).ToListAsync();
        }
    }
}
