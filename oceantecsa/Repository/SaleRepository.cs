using Microsoft.EntityFrameworkCore;
using oceantecsa.Data;
using oceantecsa.Interface;
using oceantecsa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oceantecsa.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly CasherDbContext _context;

        public SaleRepository(CasherDbContext context)
        {
            _context = context;
        }

        public async Task<Sales> GetByIdAsync(int id)
        {
            return await _context.Sales.FindAsync(id);
        }

        public async Task<List<Sales>> GetAllAsync()
        {
            return await _context.Sales.ToListAsync();
        }

        public async Task AddAsync(Sales sale)
        {
            await _context.Sales.AddAsync(sale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Sales sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var sale = await _context.Sales.FindAsync(id);
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}
