using Biblioteka_ASP.Models;

namespace Biblioteka_ASP.Repositories.Interfaces
{
    public interface IKlienciRepository
    {
        Task<IEnumerable<Klienci>> GetAllAsync();
        Task<Klienci> GetByIdAsync(int id);
        Task AddAsync(Klienci klient);
        Task UpdateAsync(Klienci klient);
        Task DeleteAsync(int id);
    }
}
