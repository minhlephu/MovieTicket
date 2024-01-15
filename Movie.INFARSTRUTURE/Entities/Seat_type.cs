using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Seat_type
    {
        public int seat_type_id { get; set; }
        public string seat_name { get; set; }
        public int surcharge { get; set; }
        public List<Seat> seat { get; set; }
    }
}
