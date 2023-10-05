using BasicECommerceApp.Application.Repositories.AppUser;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Domain.Entities.Auth;
using BasicECommerceApp.Persistance.Contexts;
using BasicECommerceApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceApp.Persistance.Repositories.Visitor
{
    public class AppUserReadRepository : GenericReadRepository<Domain.Entities.Auth.AppUser>, IAppUserReadRepository
    {
        public AppUserReadRepository(BasicECommerceAppDbContext context) : base(context)
        {

        } 

        public async Task<AppUser> GetSingleUserWithCartAndCartItemsAsync(string userId)
        {
            return await _context.Users.Include(x => x.Carts).ThenInclude(x => x.CartItems).Where(x => x.Id == userId).SingleOrDefaultAsync(x => x.Id == userId);
        }
    }
}