using Biblioteka_ASP.Data;
using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Classes
{
    public class KsiazkiRepository : IKsiazkiRepository
    {
        private readonly BibliotekaDbContext _context;

        public KsiazkiRepository(BibliotekaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ksiazki>> GetAllAsync()
        {
            return await _context.Ksiazki
                .Include(k => k.Gatunki)
                .ToListAsync();
        }

        public async Task<Ksiazki> GetByIdAsync(int id)
        {
            return await _context.Ksiazki
                .Include(k => k.Gatunki)
                .FirstOrDefaultAsync(k => k.ID_Ksiazki == id);
        }

        public async Task AddAsync(Ksiazki ksiazka)
        {
            await _context.Ksiazki.AddAsync(ksiazka);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ksiazki ksiazka)
        {
            _context.Ksiazki.Update(ksiazka);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ksiazka = await GetByIdAsync(id);
            if (ksiazka != null)
            {
                _context.Ksiazki.Remove(ksiazka);
                await _context.SaveChangesAsync();
            }
        }
    }
}