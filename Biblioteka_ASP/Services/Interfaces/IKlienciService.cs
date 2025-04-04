using Biblioteka_ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IKlienciService
    {
        Task<IEnumerable<Klienci>> GetAllAsync();
        Task<PaginatedList<Klienci>> GetPaginatedListAsync(int pageNumber, int pageSize);
        Task<Klienci> GetByIdAsync(int id);
        Task AddAsync(Klienci klient);
        Task UpdateAsync(Klienci klient);
        Task DeleteAsync(int id);
    }
}