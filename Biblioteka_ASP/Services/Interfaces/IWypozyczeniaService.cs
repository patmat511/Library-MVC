using Biblioteka_ASP.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteka_ASP.Services.Interfaces
{
    public interface IWypozyczeniaService
    {
        IQueryable<Wypozyczenia> GetAll();
        Task<Wypozyczenia> GetByIdAsync(int id);
        Task AddAsync(Wypozyczenia wypozyczenie);
        Task UpdateAsync(Wypozyczenia wypozyczenie);
        Task DeleteAsync(int id);
        Task<IEnumerable<KeyValuePair<Ksiazki, int>>> GetMostBorrowedBooksAsync(int topN);
    }
}