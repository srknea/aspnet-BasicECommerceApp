using BasicECommerceApp.Application.Repositories.AppUser;
using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Visitor;
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
    public class AppUserWriteRepository : GenericWriteRepository<Domain.Entities.Auth.AppUser>, IAppUserWriteRepository
    {
        public AppUserWriteRepository(BasicECommerceAppDbContext context) : base(context)
        {

        }
    }
}
