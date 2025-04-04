using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka_ASP.Models
{
    public class Ksiazki
    {
        [Key]
        public int ID_Ksiazki { get; set; }

        [StringLength(75)]
        public required string Tytul { get; set; }

        [StringLength(50)]
        public required string Autor { get; set; }

        public int Rok_Wydania { get; set; }

        [ForeignKey("Gatunki")]
        public int ID_Gatunku { get; set; }

        public int Ilosc_Dostepna { get; set; }

        public virtual Gatunki Gatunki { get; set; }

        public virtual ICollection<Wypozyczenia> Wypozyczenia { get; set; } = new List<Wypozyczenia>();
    }
}
