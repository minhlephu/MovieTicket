using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.MovieModel;

namespace Movie.SERVICES.Interfaces.IRepositories
{
    public interface IMovieRepository : IGenericRepository<INFARSTRUTURE.Entities.Movie>
    {
        public ListMovie GetListMovie(int page, int pageSize, string filter = "");
    }
}

