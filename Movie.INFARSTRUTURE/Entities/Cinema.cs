using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Cinema
    {
        public int cinema_id { get; set; }
        public string cinema_name { get; set; }
        public string cinema_address { get; set; }
        public string cinema_tel { get; set; }
        public string cinema_email { get; set; }
        public int city_id { get; set; }
        public City city { get; set; }
        public List<Theater> theater { get; set; }
    }
}
