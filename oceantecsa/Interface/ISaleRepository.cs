using oceantecsa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oceantecsa.Interface
{
    public interface ISaleRepository
    {
        Task<Sales> GetByIdAsync(int id);
        Task<List<Sales>> GetAllAsync();
        Task AddAsync(Sales sale);
        Task UpdateAsync(Sales sale);
        Task DeleteAsync(int id);
    }
}
