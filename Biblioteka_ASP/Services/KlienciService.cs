using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services
{
    public class KlienciService : IKlienciService
    {
        private readonly IKlienciRepository _klienciRepository;

        public KlienciService(IKlienciRepository klienciRepository)
        {
            _klienciRepository = klienciRepository;
        }

        public async Task<IEnumerable<Klienci>> GetAllAsync()
        {
            return await _klienciRepository.GetAllAsync();
        }

        public async Task<PaginatedList<Klienci>> GetPaginatedListAsync(int pageNumber, int pageSize)
        {
            var klienci = await _klienciRepository.GetAllAsync();
            return PaginatedList<Klienci>.Create(klienci, pageNumber, pageSize);
        }

        public async Task<Klienci> GetByIdAsync(int id)
        {
            return await _klienciRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Klienci klient)
        {
            await _klienciRepository.AddAsync(klient);
        }

        public async Task UpdateAsync(Klienci klient)
        {
            await _klienciRepository.UpdateAsync(klient);
        }

        public async Task DeleteAsync(int id)
        {
            await _klienciRepository.DeleteAsync(id);
        }
    }
}