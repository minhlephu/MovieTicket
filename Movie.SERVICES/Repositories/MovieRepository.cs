using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;

namespace Movie.SERVICES.Repositories
{
    public class MovieRepository : GenericRipository<INFARSTRUTURE.Entities.Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
