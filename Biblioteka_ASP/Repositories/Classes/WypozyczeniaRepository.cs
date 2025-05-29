using Biblioteka_ASP.Data;
using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Classes
{
    public class WypozyczeniaRepository : IWypozyczeniaRepository
    {
        private readonly BibliotekaDbContext _context;

        public WypozyczeniaRepository(BibliotekaDbContext context)
        {
            _context = context;
        }

        public IQueryable<Wypozyczenia> GetAllAsync()
        {
            return _context.Wypozyczenia
                .Include(w => w.Ksiazki)
                .Include(w => w.Klienci);
        }

        public async Task<Wypozyczenia> GetByIdAsync(int id)
        {
            return await _context.Wypozyczenia
                .Include(w => w.Ksiazki)
                .Include(w => w.Klienci)
                .FirstOrDefaultAsync(w => w.ID_Wypozyczenia == id);
        }

        public async Task AddAsync(Wypozyczenia wypozyczenie)
        {
            await _context.Wypozyczenia.AddAsync(wypozyczenie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Wypozyczenia wypozyczenie)
        {
            _context.Wypozyczenia.Update(wypozyczenie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie != null)
            {
                _context.Wypozyczenia.Remove(wypozyczenie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<KeyValuePair<Ksiazki, int>>> GetMostBorrowedBooksAsync(int topN)
        {
            return await _context.Wypozyczenia
                .GroupBy(w => w.Ksiazki)
                .Select(g => new KeyValuePair<Ksiazki, int>(g.Key, g.Count()))
                .OrderByDescending(x => x.Value)
                .Take(topN)
                .ToListAsync();
        }
    }
}