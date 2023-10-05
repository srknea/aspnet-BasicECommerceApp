using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories.Visitor
{
    public interface IVisitorReadRepository : IGenericReadRepository<Domain.Entities.Visitor>
    {
        Task<Domain.Entities.Visitor> GetSingleVisitorWithCartAndCartItemsAsync(string visitorId);
    }
}
