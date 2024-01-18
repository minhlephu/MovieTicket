using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces.IRepositories;

namespace Movie.SERVICES.Repositories
{
    public class MovieRepository : GenericRipository<INFARSTRUTURE.Entities.Movie>, IMovieRepository
    {
        private readonly IMapper _mapper;
        public MovieRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
    }
}
