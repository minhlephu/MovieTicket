using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
   
    public class Genre
    {
        public int genre_id { get; set; }
        public string genre_name { get; set; }
        public List<Movie> movies { get; set; }
    }
}
