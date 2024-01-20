using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IServices;


namespace Movie.SERVICES.Services
{
    public class MovieService 
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
           
            return false;
        }
         
        public Task<bool> UpdateMovie(int id, MovieViewModel movie)
        {
            throw new NotImplementedException();
        }
    }
}
