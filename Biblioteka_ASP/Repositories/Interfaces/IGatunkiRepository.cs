using Biblioteka_ASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IGatunkiRepository
    {
        IQueryable<Gatunki> GetAll();
        Task<IEnumerable<Gatunki>> GetAllAsync();
        Task<Gatunki> GetByIdAsync(int id);
        Task AddAsync(Gatunki gatunek);
        Task UpdateAsync(Gatunki gatunek);
        Task DeleteAsync(int id);
    }
}