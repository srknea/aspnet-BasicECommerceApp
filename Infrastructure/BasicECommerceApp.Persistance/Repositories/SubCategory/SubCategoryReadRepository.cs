using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Exceptions;
using BasicECommerceApp.Application.Repositories.SubCategory;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Repositories.SubCategory
{
    public class SubCategoryReadRepository : GenericReadRepository<Domain.Entities.SubCategory>, ISubCategoryReadRepository
    {
        public SubCategoryReadRepository(BasicECommerceAppDbContext context) : base(context)
        {

        }

        public async Task<Domain.Entities.SubCategory> GetSubCategoryByNameWithCategoryAndProducts(string categoryName)
        {
            var subCategoryWithCategoryAndProducts = await _context.SubCategories.Include(x => x.Category).Where(x => x.Name == categoryName).Include(x => x.Products).FirstOrDefaultAsync();

            if (subCategoryWithCategoryAndProducts == null)
            {
                throw new ClientSideException($"{categoryName} adındaki alt kategori bulunamadı");
            }

            return subCategoryWithCategoryAndProducts;
        }
    }
}
