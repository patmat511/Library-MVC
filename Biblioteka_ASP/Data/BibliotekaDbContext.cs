using Biblioteka_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka_ASP.Data
{
    public class BibliotekaDbContext : DbContext
    {
        public DbSet<Gatunki> Gatunki { get; set; }
        public DbSet<Ksiazki> Ksiazki { get; set; }
        public DbSet<Klienci> Klienci { get; set; }
        public DbSet<Wypozyczenia> Wypozyczenia { get; set; }

        public BibliotekaDbContext(DbContextOptions<BibliotekaDbContext> options)
            : base(options)
        {
        }
    }
}
