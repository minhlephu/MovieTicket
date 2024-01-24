using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Fare
    {
        public int FareID { get; set; }
        public string? FareName { get; set; }
        public int UnitPrice { get; set; }
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
