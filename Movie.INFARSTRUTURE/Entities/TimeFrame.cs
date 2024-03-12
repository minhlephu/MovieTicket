using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Entities
{
    public class TimeFrame
    {
        public int TimeFrameID { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public virtual ICollection<Show> Show { get; set; }
    }
}
