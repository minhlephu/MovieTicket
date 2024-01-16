using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; set; }
        int Save();
    }
}
