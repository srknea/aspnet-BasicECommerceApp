using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Domain.Entities.Common;
using BasicECommerceApp.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BasicECommerceApp.Persistence.Repositories
{
    public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : BaseEntity
    {
        readonly private BasicECommerceAppDbContext _context;
        public GenericWriteRepository(BasicECommerceAppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            //_context.Entry(entity).State = EntityState.Modified;
            Table.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }

        /*
        public async Task<int> SaveAsync()
        { 
            return await _context.SaveChangesAsync();
        }
        */
        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();
    }
}
