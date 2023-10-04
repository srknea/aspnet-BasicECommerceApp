using BasicECommerceApp.Application.Exceptions;
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
        private readonly BasicECommerceAppDbContext _context;
        public CategoryReadRepository(BasicECommerceAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Category> GetCategoryByNameWithProducts(string categoryName)
        {
            var subCategoryWithCategoryAndProducts = await _context.Categories.Include(x => x.Products).FirstOrDefaultAsync();

            if (subCategoryWithCategoryAndProducts == null)
            {
                throw new ClientSideException($"{categoryName} adındaki alt kategori bulunamadı");
            }

            return subCategoryWithCategoryAndProducts;
        }

        public async Task<List<Domain.Entities.Category>> GetAllCategoriesWithSubCategories()
        {
            var allCategoriesWithChildren = await GetAllCategoriesWithChildren();
            
            return allCategoriesWithChildren;
        }

        private async Task<List<Domain.Entities.Category>> GetAllCategoriesWithChildren()
        {
            // Tüm kök kategorileri çekme (ParentId null olanlar)
            var rootCategories = await _context.Categories
                .Include(c => c.Children)
                .Where(c => c.ParentId == null)
                .OrderBy(c => c.Name) //alfabetik olarak sırala
                .ToListAsync();

            // Kök kategorilerin alt kategorilerini recursive (tekrarlanan) bir şekilde çekme
            foreach (var rootCategory in rootCategories)
            {
                rootCategory.Children = await GetChildrenRecursive(rootCategory.Id);
            }

            return rootCategories;
        }

        private async Task<List<Domain.Entities.Category>> GetChildrenRecursive(Guid parentId)
        {
            var children = await _context.Categories
                .Include(c => c.Children)
                .Where(c => c.ParentId == parentId)
                .OrderBy(c => c.Name) //alfabetik olarak sırala
                .ToListAsync();

            foreach (var child in children)
            {
                child.Children = await GetChildrenRecursive(child.Id);
            }

            return children;
        }
    }
}
