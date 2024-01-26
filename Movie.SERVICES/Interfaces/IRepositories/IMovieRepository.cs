﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.INFARSTRUTURE.Entities;
using Movie.INFARSTRUTURE.Models.MovieModel;
using Movie.INFARSTRUTURE.Utilities;

namespace Movie.SERVICES.Interfaces.IRepositories
{
    public interface IMovieRepository : IGenericRepository<INFARSTRUTURE.Entities.Movie>
    {
        public Task<PageList<MovieResultVm>> GetListMovie(int page, int pageSize, string filter = "");
    }
}

