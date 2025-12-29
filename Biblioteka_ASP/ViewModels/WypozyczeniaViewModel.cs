namespace Biblioteka_ASP.ViewModels
{
    public class WypozyczeniaViewModel
    {
        public int ID_Wypozyczenia { get; set; }
        public int ID_Ksiazki { get; set; }
        public string TytulKsiazki { get; set; }
        public int ID_Klienta { get; set; }
        public string ImieKlienta { get; set; }
        public DateTime Data_Wypozyczenia { get; set; }
        public DateTime Data_Zwrotu { get; set; }
        public int Kara { get; set; }
    }
}
