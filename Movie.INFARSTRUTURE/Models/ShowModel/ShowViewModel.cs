﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.INFARSTRUTURE.Models.ShowModel
{
    public class ShowViewModel
    {
        public DateTime ShowDate { get; set; }
        public int MovieID { get; set; }
        public int MovieTypeID { get; set; }
        public int TheaterID { get; set; }
    }
}
