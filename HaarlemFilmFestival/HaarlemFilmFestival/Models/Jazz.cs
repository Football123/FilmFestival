﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Jazz : Event
    {
        public string Band { get; set; }
        public string JazzDescription { get; set; }
    }
}