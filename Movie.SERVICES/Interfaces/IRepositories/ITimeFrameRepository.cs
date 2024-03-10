using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.INFARSTRUTURE.Models.TimeFrame;
using Movie.INFARSTRUTURE.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Interfaces.IRepositories
{
    public interface ITimeFrameRepository:IGenericRepository<TimeFrame>
    {
        public Task<PageList<TimeFrameResultVm>> GetListTimeFrame(int page, int pageSize);
    }
}
