using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HaarlemFilmFestival.Repositories;
using HaarlemFilmFestival.Controllers;

namespace HaarlemFilmFestival.Models
{
    public class HistoricViewModel
    {
        private IHistoricRepository historicrepository = new HistoricRepository();

        public HistoricViewModel()
        {

        }


    }
}