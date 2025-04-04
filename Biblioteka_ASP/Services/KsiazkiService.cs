using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services
{
    public class KsiazkiService : IKsiazkiService
    {
        private readonly IKsiazkiRepository _ksiazkiRepository;
        public KsiazkiService(IKsiazkiRepository ksiazkiRepository)
        {
            _ksiazkiRepository = ksiazkiRepository;
        }

        public async Task<IEnumerable<Ksiazki>> GetAllAsync()
        {
            return await _ksiazkiRepository.GetAllAsync();
        }

        public async Task<Ksiazki> GetByIdAsync(int id)
        {
            return await _ksiazkiRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Ksiazki ksiazka)
        {
            await _ksiazkiRepository.AddAsync(ksiazka);
        }

        public async Task UpdateAsync(Ksiazki ksiazka)
        {
            await _ksiazkiRepository.UpdateAsync(ksiazka);
        }

        public async Task DeleteAsync(int id)
        {
            await _ksiazkiRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Ksiazki>> SearchAsync(string searchString)
        {
            var ksiazki = await _ksiazkiRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                ksiazki = ksiazki.Where(k =>
                    k.Tytul.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    k.Autor.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                ).ToList();
            }
            return ksiazki;
        }

        public async Task<PaginatedList<Ksiazki>> GetPaginatedListAsync(int pageNumber, int pageSize, string searchString = null)
        {
            var ksiazki = await SearchAsync(searchString);
            return PaginatedList<Ksiazki>.Create(ksiazki, pageNumber, pageSize);
        }
    }
}