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
    public class CategoryWriteRepository : GenericWriteRepository<Domain.Entities.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(BasicECommerceAppDbContext context) : base(context)
        {
        }   
    }
}
