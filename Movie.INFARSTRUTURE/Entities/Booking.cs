using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Booking
    {
        public int bk_id { get; set; }
        public DateTime sale_date { get; set; }
        public int price { get; set; }
        public int show_id { get; set; }
        public int seat_id { get; set; }
        public int fare_id { get; set; }
        public string user_id { get; set; }
        public Fare fare { get; set; }
        public Seat seat { get; set; }
        public ApplicationUser user { get; set; }
    }
}
