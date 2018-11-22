using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class Location
    {
        [Key]
        public int LocatieId { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public int Telefoonnummer { get; set; }
        public int Capaciteit { get; set; }
        public int EventId { get; set; }
    }
}