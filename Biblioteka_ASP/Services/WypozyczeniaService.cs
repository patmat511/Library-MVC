using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services
{
    public class WypozyczeniaService : IWypozyczeniaService
    {
        private readonly IWypozyczeniaRepository _wypozyczeniaRepository;

        public WypozyczeniaService(IWypozyczeniaRepository wypozyczeniaRepository)
        {
            _wypozyczeniaRepository = wypozyczeniaRepository;
        }

        public async Task<IEnumerable<Wypozyczenia>> GetAllAsync()
        {
            return await _wypozyczeniaRepository.GetAllAsync();
        }

        public async Task<Wypozyczenia> GetByIdAsync(int id)
        {
            return await _wypozyczeniaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Wypozyczenia wypozyczenie)
        {
            await _wypozyczeniaRepository.AddAsync(wypozyczenie);
        }

        public async Task UpdateAsync(Wypozyczenia wypozyczenie)
        {
            await _wypozyczeniaRepository.UpdateAsync(wypozyczenie);
        }

        public async Task DeleteAsync(int id)
        {
            await _wypozyczeniaRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<KeyValuePair<Ksiazki, int>>> GetMostBorrowedBooksAsync(int topN)
        {
            return await _wypozyczeniaRepository.GetMostBorrowedBooksAsync(topN);
        }
    }
}