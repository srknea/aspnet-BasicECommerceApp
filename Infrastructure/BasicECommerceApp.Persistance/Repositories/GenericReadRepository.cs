using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Domain.Entities.Common;
using BasicECommerceApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasicECommerceApp.Persistence.Repositories
{
    public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class
    {
        private readonly BasicECommerceAppDbContext _context;
        private readonly DbSet<T> Table;
        public GenericReadRepository(BasicECommerceAppDbContext context)
        {
            _context = context;
            Table = context.Set<T>();
        }

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