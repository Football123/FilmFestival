﻿using HaarlemFilmFestival.Models;
using HaarlemFilmFestival.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Repositories
{
    interface IJazzRepository
    { 
        IEnumerable<Jazz> GetJazz();
        IEnumerable<Artist> GetArtists(IEnumerable<Jazz> Jazzevents);
        Jazz GetJazz(int jazzId);
        IEnumerable<Jazz> GetJazzPerDay(DateTime day);
    }
}