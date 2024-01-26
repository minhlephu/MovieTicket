using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Models.TheaterModel
{
    public class TheaterResultVm
    {
        public int TheaterID { get; set; }
        public int CinemaID { get; set; }
        public int QtySeat { get; set; }
        public int SeatID { get; set; }
    }
}
