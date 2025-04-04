using Biblioteka_ASP.Data;
using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka_ASP.Repositories.Classes
{
    public class KlienciRepository : IKlienciRepository
    {
        private readonly BibliotekaDbContext _context;

        public KlienciRepository(BibliotekaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Klienci>> GetAllAsync()
        {
            return await _context.Klienci.ToListAsync();
        }

        public async Task<Klienci> GetByIdAsync(int id)
        {
            return await _context.Klienci
                .FirstOrDefaultAsync(k => k.ID_Klienta == id);
        }

        public async Task AddAsync(Klienci klient)
        {
            await _context.Klienci.AddAsync(klient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Klienci klient)
        {
            _context.Klienci.Update(klient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var klient = await _context.Klienci.FindAsync(id);
            if (klient != null)
            {
                _context.Klienci.Remove(klient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
