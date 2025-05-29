using Biblioteka_ASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IKsiazkiService
    {
        IQueryable<Ksiazki> GetAll();
        Task<Ksiazki> GetByIdAsync(int id);
        Task AddAsync(Ksiazki ksiazka);
        Task UpdateAsync(Ksiazki ksiazka);
        Task DeleteAsync(int id);
        IQueryable<Ksiazki> Search(string searchString);
        Task<PaginatedList<Ksiazki>> GetPaginatedListAsync(int pageNumber, int pageSize, string searchString = null);
    }
}

