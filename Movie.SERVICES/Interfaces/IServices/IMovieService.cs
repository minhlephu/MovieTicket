using Movie.INFARSTRUTURE.Models.MovieModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces.IServices
{
    public interface IMovieService
    {
        Task<bool> CreateMovie(MovieViewModel movieVM);
        Task<IEnumerable<MovieViewModel>> GetAllMovie();
        Task<bool> UpdateMovie(int id,MovieViewModel movie);
        Task<bool> DeleteMovie(int id);
    }
}
