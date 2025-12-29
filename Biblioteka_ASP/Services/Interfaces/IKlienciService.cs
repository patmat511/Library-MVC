using Biblioteka_ASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IKlienciService
    {
        IQueryable<Klienci> GetAll();
        PaginatedList<Klienci> GetPaginatedList(int pageNumber, int pageSize);
        Task<Klienci> GetByIdAsync(int id);
        Task AddAsync(Klienci klient);
        Task UpdateAsync(Klienci klient);
        Task DeleteAsync(int id);
    }
}