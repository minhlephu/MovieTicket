using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; set; }
        public UnitOfWork(ApplicationDbContext context,IUserRepository userRepositories)
        { 
             _context=context;
            Users= userRepositories;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
