using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HaarlemFilmFestival.Models
{
    public class RegisterModel
    {
        [Required] public string Name { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public string EmailAddres { get; set; }
     //   [Required] public string PaymentMethod { get; set; }
        [Required] public PaymentMethod PaymentMethod { get; set; }
    }
}