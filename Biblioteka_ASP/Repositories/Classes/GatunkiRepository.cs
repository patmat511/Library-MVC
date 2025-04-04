using Biblioteka_ASP.Data;
using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Biblioteka_ASP.Repositories.Classes
{
    public class GatunkiRepository : IGatunkiRepository
    {
        private readonly BibliotekaDbContext _context;

        public GatunkiRepository(BibliotekaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gatunki>> GetAllAsync()
        {
            return await _context.Gatunki.ToListAsync();
        }

        public async Task<Gatunki> GetByIdAsync(int id)
        {
            return await _context.Gatunki
                .FirstOrDefaultAsync(g => g.ID_Gatunku == id);
        }

        public async Task AddAsync(Gatunki gatunek)
        {
            await _context.Gatunki.AddAsync(gatunek);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Gatunki gatunek)
        {
            _context.Gatunki.Update(gatunek);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var gatunek = await _context.Gatunki.FindAsync(id);
            if (gatunek != null)
            {
                _context.Gatunki.Remove(gatunek);
                await _context.SaveChangesAsync();
            }
        }
    }
}
