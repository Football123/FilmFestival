﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Restaurant { get; set; }
        public string Rang { get; set; }
        public int Rangprijs { get; set; }
        public string Type { get; set; }
        public int EventId { get; set; }
    }
}