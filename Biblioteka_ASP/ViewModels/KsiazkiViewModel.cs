using Biblioteka_ASP.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka_ASP.ViewModels
{
    public class KsiazkiViewModel
    {
        public int ID_Ksiazki { get; set; }
        public required string Tytul { get; set; }
        public required string Autor { get; set; }
        public int Rok_Wydania { get; set; }
        public int ID_Gatunku { get; set; }
        public string NazwaGatunku { get; set; }
        public int Ilosc_Dostepna { get; set; }
        public int LiczbaWypozyczen { get; set; }
    }
}
