using System.ComponentModel.DataAnnotations;

namespace Biblioteka_ASP.Models
{
    public class Klienci
    {
        [Key]
        public int ID_Klienta { get; set; }

        [StringLength(50)] 
        public required string Imie { get; set; }

        [StringLength(40)]
        public required string Email { get; set; }

        [StringLength(15)]
        public required string Telefon { get; set; }

        [StringLength(75)]
        public required string Adres { get; set; }

        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; } = new List<Wypozyczenia>();
    }
}
