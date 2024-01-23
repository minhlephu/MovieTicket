using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Seat
    {
        public int SeatID { get; set; }
        public string SeatName { get; set; }
        public string Status { get; set; }
        public int TheaterID { get; set; }
        public int SeatTypeID { get; set; }
        public SeatType SeatType { get; set; }
        public virtual Theater Theater { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
