using BasicECommerceApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //DbSet<T> Table { get; }
    }
}
