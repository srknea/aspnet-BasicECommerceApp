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
    public class VisitorWriteRepository : GenericWriteRepository<Domain.Entities.Visitor>, IVisitorWriteRepository
    {
        public VisitorWriteRepository(BasicECommerceAppDbContext context) : base(context)
        {

        }
    }
}
