using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasicECommerceApp.Persistance.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {
        private readonly IGenericWriteRepository<T> _writeRepository;
        private readonly IGenericReadRepository<T> _readRepository;
        public GenericService(IGenericReadRepository<T> readRepository, IGenericWriteRepository<T> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _writeRepository.AddAsync(entity);
            await _writeRepository.SaveAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _writeRepository.AddRangeAsync(entities);
            await _writeRepository.SaveAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _readRepository.AnyAsync(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _readRepository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            var hasProduct = await _readRepository.GetByIdAsync(id);

            return hasProduct;
        }

        public async Task RemoveAsync(T entity)
        {
            _writeRepository.Remove(entity);
            await _writeRepository.SaveAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _writeRepository.RemoveRange(entities);
            await _writeRepository.SaveAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _writeRepository.Update(entity);
            await _writeRepository.SaveAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _readRepository.Where(expression);
        }
    }
}
