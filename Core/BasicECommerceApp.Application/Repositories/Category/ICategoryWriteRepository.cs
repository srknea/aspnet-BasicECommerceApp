using BasicECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories.Category
{
    public interface ICategoryWriteRepository : IGenericWriteRepository<Domain.Entities.Category>
    {
    }
}
