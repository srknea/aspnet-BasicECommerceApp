using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories.AppUser
{
    public interface IAppUserReadRepository : IGenericReadRepository<Domain.Entities.Auth.AppUser>
    {
        Task<Domain.Entities.Auth.AppUser> GetSingleUserWithCartAndCartItemsAsync(string userId);
    }
}
