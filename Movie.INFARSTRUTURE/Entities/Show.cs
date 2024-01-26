using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class Show
    {
        public int ShowID { get; set; }    
        public DateTime ShowDate { get; set; }
        public int MovieID { get; set; }
        public int MovieTypeID { get; set; }
        public int TheaterID { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual MovieType MovieType { get; set; }
        public virtual Theater Theater { get; set; }
        public virtual ICollection<TimeFrame> TimeFrame { get; set; }

    }
}
