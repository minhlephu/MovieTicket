using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IServices;
using Movie.SERVICES.Models.MovieModel;

namespace Movie.SERVICES.Services
{
    public class MovieService : IMovieService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public MovieService(IMapper mapper, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<bool> CreateMovie(MovieViewModel movieVM)
        {
            var movie =  _mapper.Map<INFARSTRUTURE.Entities.Movie>(movieVM);
            if (movie != null)
            {
                movie.mv_name = movieVM.mv_name;
                movie.release_date = movieVM.release_date;
                movie.photo = movieVM.photo;
                movie.hot = movieVM.hot;
                movie.comming_soon = movieVM.comming_soon;
                movie.show_now = movieVM.show_now;
                movie.summary = movieVM.summary;
                movie.duration = movieVM.duration;
                movie.genre_id = movieVM.genre_id;
                movie.trailer = movieVM.trailer;
                await _unitOfWork.Movies.Add(movie);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteMovie(int id)
        {           
            var isDelete = _unitOfWork.Movies.Delete(id);
            if (isDelete != null)
            {
                return true;

            }
           return false;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMovie()
        {
            var listMovie = _unitOfWork.Movies.GetAll();
            var reponses = listMovie.Result.Select(c => _mapper.Map<MovieViewModel>(c));
            return reponses;
        }
         
        public Task<bool> UpdateMovie(int id, MovieViewModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
