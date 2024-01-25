using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;

namespace Movie.SERVICES.Repositories
{
    public class MovieRepository : GenericRipository<INFARSTRUTURE.Entities.Movie>, IMovieRepository
    {
        private IMapper _mapper;
        public MovieRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = mapper;
        }

        public ListMovie GetListMovie(int page, int pageSize, string filter = "")
        {
           var query = _context.Movies.AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(mv=>mv.MovieName.Contains(filter));
            }
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount/pageSize);
            var result = new ListMovie
            {
                ToTalCount = totalCount,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Movies = query.ToList(),
            };
            return result;
        }

    }
}
