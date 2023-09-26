using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Domain.Entities.Common;
using BasicECommerceApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasicECommerceApp.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly BasicECommerceAppDbContext _context;
        public ReadRepository(BasicECommerceAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return Table.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await Table.FindAsync(Guid.Parse(id));
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }
    }
}