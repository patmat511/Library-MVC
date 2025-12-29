using Biblioteka_ASP.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IKsiazkiRepository
    {
        IQueryable<Ksiazki> GetAllAsync();
        Task<Ksiazki> GetByIdAsync(int id);
        Task AddAsync(Ksiazki ksiazka);
        Task UpdateAsync(Ksiazki ksiazka);
        Task DeleteAsync(int id);
    }
}