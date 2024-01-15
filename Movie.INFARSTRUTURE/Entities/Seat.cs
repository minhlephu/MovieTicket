using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Seat
    {
        public int seat_id { get; set; }
        public string row_loc { get; set; }
        public int col_loc { get; set; }
        public int status { get; set; }
        public int theater_id { get; set; }
        public int seat_type_id { get; set; }
        public Seat_type seat_type { get; set; }
        public Theater theater { get; set; }
        public List<Booking> booking { get; set; }
    }
}
