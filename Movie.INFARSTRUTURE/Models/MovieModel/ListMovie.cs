using Movie.INFARSTRUTURE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Models.MovieModel
{
    public class ListMovie
    {
        public int ToTalCount { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public ICollection<Movie.INFARSTRUTURE.Entities.Movie> Movies { get; set; }
    }
}
