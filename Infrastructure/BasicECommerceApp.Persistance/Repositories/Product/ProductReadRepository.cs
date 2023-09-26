using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
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
    }
}
