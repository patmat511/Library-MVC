using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace Biblioteka_ASP.Models
{
    public class ApplicationUser : IdentityUser
    {
 
        [MaxLength(30)]
        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Imie { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }
    }
}
