using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Visitor;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.Repositories.Visitor
{
    public class VisitorReadRepository : GenericReadRepository<Domain.Entities.Visitor>, IVisitorReadRepository
    {
        public VisitorReadRepository(BasicECommerceAppDbContext context) : base(context)
        {

        }

        public async Task<Domain.Entities.Visitor> GetSingleVisitorWithCartAndCartItemsAsync(string visitorId)
        {
            return await _context.Visitors.Include(x => x.Carts).ThenInclude(x => x.CartItems).Where(x => x.Id == Guid.Parse(visitorId)).SingleOrDefaultAsync(x => x.Id == Guid.Parse(visitorId));
        }
    }
}
