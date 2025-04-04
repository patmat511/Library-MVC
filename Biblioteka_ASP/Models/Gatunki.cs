using System.ComponentModel.DataAnnotations;

namespace Biblioteka_ASP.Models
{
    public class Gatunki
    {
        [Key]
        public int ID_Gatunku { get; set; }

        [StringLength(50)]
        public required string Gatunek { get; set; }

        public virtual ICollection<Ksiazki> Ksiazki { get; set; } = new List<Ksiazki>();
    }
}

