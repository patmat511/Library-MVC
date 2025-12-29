using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System;
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

        public IQueryable<Ksiazki> GetAll()
        {
            return _ksiazkiRepository.GetAllAsync();
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

        public IQueryable<Ksiazki> Search(string searchString)
        {
            var ksiazki = GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                ksiazki = ksiazki.Where(k =>
                    k.Tytul.Contains(searchString) ||
                    k.Autor.Contains(searchString)
                );
            }
            return ksiazki;
        }

        public async Task<PaginatedList<Ksiazki>> GetPaginatedListAsync(int pageNumber, int pageSize, string searchString = null)
        {
            var query = Search(searchString);
            return await PaginatedList<Ksiazki>.CreateAsync(query, pageNumber, pageSize);
        }
    }
}