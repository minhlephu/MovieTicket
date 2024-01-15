using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Movie_type
    {
        public int mv_type_id { get; set; }
        public string mv_type_name { get; set; }
        public int surcharge { get; set; }
        public List<Show> show { get; set; }
    }
}
