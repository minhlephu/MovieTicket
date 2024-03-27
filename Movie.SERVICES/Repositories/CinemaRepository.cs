using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Models.CinemaModel;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.INFARSTRUTURE.Utilities;
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
        public async Task<PageList<CinemaResultVm>> GetListCinema(int page, int pageSize, string filter = "")
        {
            var query = _context.Cinemas.AsQueryable();
            var listCinema = _context.Cinemas
                .Join(_context.Cities, m => m.CinemaID, n => n.CityID, (m, n) => new { m, n })
                .Select(cm => new CinemaResultVm
                {
                    CinemaID = cm.m.CinemaID,
                    CinemaName = cm.m.CinemaName,
                    CinemaAddress = cm.m.CinemaAddress,
                    CityID = cm.n.CityID,
                    CityName = cm.n.CityName
                });

            if (!string.IsNullOrEmpty(filter))
            {
                listCinema = listCinema.Where(mv => mv.CinemaName.Contains(filter));
            }
            var totalCount = listCinema.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            listCinema = listCinema.Skip((page - 1) * pageSize).Take(pageSize);
            var cinemas = await listCinema.ToListAsync();
            var resultItems = _mapper.Map<IEnumerable<CinemaResultVm>>(cinemas);
            var result = PageList<CinemaResultVm>.Create(resultItems, page, pageSize, totalCount, totalPages);
            return result;
        }
    }
}
