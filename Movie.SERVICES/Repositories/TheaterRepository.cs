using AutoMapper;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class TheaterRepository:GenericRipository<Theater>,ITheaterRepository
    {
        private IMapper _mapper;
        public TheaterRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = mapper;
        }
    }
}
