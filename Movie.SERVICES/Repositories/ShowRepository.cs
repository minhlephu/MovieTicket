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
    public class ShowRepository:GenericRipository<Show>,IShowRepository
    {
        private IMapper _mapper;
        public ShowRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = mapper;
        }

    }
}
