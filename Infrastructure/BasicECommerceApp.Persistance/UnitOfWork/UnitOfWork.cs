using BasicECommerceApp.Application.UnitOfWork;
using BasicECommerceApp.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BasicECommerceAppDbContext _context;

        public UnitOfWork(BasicECommerceAppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        // Mümkün oldukça async metotları kullanmaya çalışacağız.
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
