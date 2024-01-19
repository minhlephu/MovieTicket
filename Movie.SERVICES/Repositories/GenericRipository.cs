using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class GenericRipository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        protected GenericRipository(ApplicationDbContext context,IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
        public async Task Add(T entity)
        {
           await _context.Set<T>().AddAsync(entity);
        }

        public async Task CreateAsync(T entity)
        {
           await _context.Set<T>().AddAsync(entity);          
        }

        public async Task<T> Delete(int id)
        {
           var entityEntry =_context.Set<T>().FindAsync(id);
            var isDelete = _context.Set<T>().Remove(entityEntry.Result);
            await _context.SaveChangesAsync();
            return isDelete.Entity;
        }

        public Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var res = await _context.Set<T>().FindAsync(id);
            return res;
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            return _unitOfWork.CommitAsync();
        }

        public async Task<T> Update(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

        public Task UpdateAsync(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Unchanged)
            {
                return Task.CompletedTask;
            }
            var entityEntry = _context.Set<T>().Update(entity);

            return entityEntry;
        }
    }
}
