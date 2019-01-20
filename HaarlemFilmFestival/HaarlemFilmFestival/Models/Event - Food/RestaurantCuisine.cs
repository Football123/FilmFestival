using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    [Table("RestaurantCuisines")]
    public class RestaurantCuisine
    {
        [Key]
        [Column("Restaurant_Id", Order = 0)]
        public int resid { get; set; }

        [Key]
        [Column("Cuisine_Id", Order = 1)]
        public int cuisid { get; set; }
    }
}