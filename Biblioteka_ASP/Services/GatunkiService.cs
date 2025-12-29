using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services
{
    public class GatunkiService : IGatunkiService
    {
        private readonly IGatunkiRepository _gatunkiRepository;

        public GatunkiService(IGatunkiRepository gatunkiRepository)
        {
            _gatunkiRepository = gatunkiRepository;
        }

        public IQueryable<Gatunki> GetAll()
        {
            return _gatunkiRepository.GetAll();
        }

        public async Task<PaginatedList<Gatunki>> GetPaginatedListAsync(int pageNumber, int pageSize)
        {
            var gatunki = GetAll();
            return PaginatedList<Gatunki>.Create(gatunki, pageNumber, pageSize);
        }

        public async Task<Gatunki> GetByIdAsync(int id)
        {
            return await _gatunkiRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Gatunki gatunek)
        {
            await _gatunkiRepository.AddAsync(gatunek);
        }

        public async Task UpdateAsync(Gatunki gatunek)
        {
            await _gatunkiRepository.UpdateAsync(gatunek);
        }

        public async Task DeleteAsync(int id)
        {
            await _gatunkiRepository.DeleteAsync(id);
        }
    }
}