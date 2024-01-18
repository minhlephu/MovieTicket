using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.SERVICES.Models.MovieModel
{
    public class MovieViewModel
    {
        public int mv_id { get; set; }
        public string? mv_name { get; set; }
        public string? trailer { get; set; }
        public string? photo { get; set; }
        public string? summary { get; set; }
        public DateTime release_date { get; set; }
        public int duration { get; set; }
        public bool comming_soon { get; set; }
        public bool show_now { get; set; }
        public bool hot { get; set; }
        public int? genre_id { get; set; }
    }
}
