using Biblioteka_ASP.Models;
using System.Linq;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IGatunkiRepository
    {
        Task<IEnumerable<Gatunki>> GetAllAsync();
        Task<Gatunki> GetByIdAsync(int id);
        Task AddAsync(Gatunki gatunek);
        Task UpdateAsync(Gatunki gatunek);
        Task DeleteAsync(int id);
    }
}
