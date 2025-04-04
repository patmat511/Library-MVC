using Biblioteka_ASP.Models;
using Biblioteka_ASP.Repositories.Interfaces;
using Biblioteka_ASP.Services.Interfaces;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Gatunki>> GetAllAsync()
        {
            return await _gatunkiRepository.GetAllAsync();
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