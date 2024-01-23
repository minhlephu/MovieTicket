using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Movie.INFARSTRUTURE.Entities
{
    public class MovieType
    {
        public int MovieTypeID { get; set; }
        public string MovieTypeName { get; set; }
        public int Surcharge { get; set; }
        public virtual ICollection<Show> Show { get; set; }
    }
}
