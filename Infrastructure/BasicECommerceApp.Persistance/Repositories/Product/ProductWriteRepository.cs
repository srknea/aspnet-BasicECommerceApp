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
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(BasicECommerceAppDbContext context) : base(context)
        {
        }
    }
}
