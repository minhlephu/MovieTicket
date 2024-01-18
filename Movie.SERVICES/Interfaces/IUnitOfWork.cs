using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.SERVICES.Interfaces.IRepositories;

namespace Movie.SERVICES.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; set; }
        IMovieRepository Movies { get; set; }
        int Save();
    }
}
