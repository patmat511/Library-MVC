using Biblioteka_ASP.Models;
namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IKsiazkiService
    {
        Task<IEnumerable<Ksiazki>> GetAllAsync();
        Task<Ksiazki> GetByIdAsync(int id);
        Task AddAsync(Ksiazki ksiazka);
        Task UpdateAsync(Ksiazki ksiazka);
        Task DeleteAsync(int id);
        Task<IEnumerable<Ksiazki>> SearchAsync(string searchString);
        Task<PaginatedList<Ksiazki>> GetPaginatedListAsync(int pageNumber, int pageSize, string searchString = null);
    }
}

