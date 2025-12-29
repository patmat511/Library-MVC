namespace Biblioteka_ASP.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public List<string> Roles { get; set; }
    }
}
