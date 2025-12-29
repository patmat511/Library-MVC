using Biblioteka_ASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IGatunkiService
    {
        IQueryable<Gatunki> GetAll();
        Task<PaginatedList<Gatunki>> GetPaginatedListAsync(int pageNumber, int pageSize);
        Task<Gatunki> GetByIdAsync(int id);
        Task AddAsync(Gatunki gatunek);
        Task UpdateAsync(Gatunki gatunek);
        Task DeleteAsync(int id);
        // test
    }
}