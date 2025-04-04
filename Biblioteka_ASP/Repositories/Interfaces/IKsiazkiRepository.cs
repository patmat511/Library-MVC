using Biblioteka_ASP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IKsiazkiRepository
    {
        Task<IEnumerable<Ksiazki>> GetAllAsync();
        Task<Ksiazki> GetByIdAsync(int id);
        Task AddAsync(Ksiazki ksiazka);
        Task UpdateAsync(Ksiazki ksiazka);
        Task DeleteAsync(int id);
    }
}