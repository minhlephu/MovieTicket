using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task DeleteAsync(T entity);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
