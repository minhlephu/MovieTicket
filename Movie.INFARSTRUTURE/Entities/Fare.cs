using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Fare
    {
        public int fare_id { get; set; }
        public string fare_name { get; set; }
        public int unit_price { get; set; }
        public List<Booking> booking { get; set; }
    }
}
