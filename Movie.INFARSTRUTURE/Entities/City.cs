using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class City
    {
        public int city_id { get; set; }
        public int city_name { get; set; }
        public List<Cinema> cinema { get; set; }
    }
}
