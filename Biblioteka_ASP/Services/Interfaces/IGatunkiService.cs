using Biblioteka_ASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IGatunkiService
    {
        Task<IEnumerable<Gatunki>> GetAllAsync();
        Task<Gatunki> GetByIdAsync(int id);
        Task AddAsync(Gatunki gatunek);
        Task UpdateAsync(Gatunki gatunek);
        Task DeleteAsync(int id);
    }
}