using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    
    public class Movie
    {
        public int mv_id { get; set; }   
        public string mv_name { get; set; }      
        public DateTime release_date { get; set; }
        public int duration { get; set; }
        public int? genre_id { get; set; }
        public Genre genre { get; set; }
        public List<Show> show { get; set; }
    }
}
