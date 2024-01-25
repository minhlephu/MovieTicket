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
    public class CinemaRepository : GenericRipository<INFARSTRUTURE.Entities.Cinema>,ICinemaRepository
    {
        private IMapper _mapper;
        public CinemaRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = mapper;
        }
    }
}
