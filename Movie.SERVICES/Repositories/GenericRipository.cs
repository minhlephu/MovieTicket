using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
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
        protected GenericRipository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
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

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            var res = await _context.Set<T>().FindAsync(id);
            return res;
        }

        public async Task<T> Update(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entityEntry.Entity;
        }

    }
}
