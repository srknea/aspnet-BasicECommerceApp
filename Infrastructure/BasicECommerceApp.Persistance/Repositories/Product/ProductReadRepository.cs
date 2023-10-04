using BasicECommerceApp.Application.Exceptions;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Repositories.Product
{
    public class ProductReadRepository : GenericReadRepository<Domain.Entities.Product>, IProductReadRepository
    {
        public ProductReadRepository(BasicECommerceAppDbContext context) : base(context)
        {
        }
        
        public async Task<Domain.Entities.Product> GetByIdProductWithCategory(string id)
        {            
            var product = await _context.Products.Include(x => x.Category).FirstOrDefaultAsync();

            if (product == null)
            {
                throw new ClientSideException($"{id}'ye sahip olan Product bulunmamaktadır.");
            }

            return product;
        }
    }
}
