using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class SeatType
    {
        public int SeatTypeID { get; set; }
        public string SeatName { get; set; }
        public int Surcharge { get; set; }
        public virtual ICollection<Seat> Seat { get; set; }
    }
}
