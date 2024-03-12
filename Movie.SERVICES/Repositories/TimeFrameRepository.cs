using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.INFARSTRUTURE;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.INFARSTRUTURE.Utilities;
using Movie.SERVICES.Interfaces;
using Movie.SERVICES.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Repositories
{
    public class TimeFrameRepository:GenericRipository<TimeFrame>, ITimeFrameRepository
    {
        private IMapper _mapper;
        public TimeFrameRepository(ApplicationDbContext context, IMapper mapper, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<PageList<TimeFrameResultVm>> GetListTimeFrame(int current, int pageSize)
        {
            var query = _context.TimeFrames.AsQueryable();
            var totalCount = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            query = query.Skip((current - 1) * pageSize).Take(pageSize);
            var timeFrames = await query.ToListAsync();
            var resultItems = _mapper.Map<IEnumerable<TimeFrameResultVm>>(timeFrames);
            var result = PageList<TimeFrameResultVm>.Create(resultItems, current, pageSize, totalCount, totalPages);
            return result;
        }
    }
}
