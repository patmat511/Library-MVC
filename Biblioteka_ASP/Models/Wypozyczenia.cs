using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka_ASP.Models
{
    public class Wypozyczenia
    {
        [Key]
        public int ID_Wypozyczenia { get; set; }

        [ForeignKey("Ksiazki")]
        public int ID_Ksiazki { get; set; }

        [ForeignKey("Klienci")]
        public int ID_Klienta { get; set; }

        public DateTime Data_Wypozyczenia { get; set; }

        public DateTime Data_Zwrotu { get; set; }

        public int Kara { get; set; }
        public virtual Ksiazki Ksiazki { get; set; }
        public virtual Klienci Klienci { get; set; }
    }
}
