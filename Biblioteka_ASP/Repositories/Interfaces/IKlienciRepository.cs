using Biblioteka_ASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IKlienciRepository
    {
        IQueryable<Klienci> GetAll();
        Task<IEnumerable<Klienci>> GetAllAsync();
        Task<Klienci> GetByIdAsync(int id);
        Task AddAsync(Klienci klient);
        Task UpdateAsync(Klienci klient);
        Task DeleteAsync(int id);
    }
}