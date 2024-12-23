using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_api.Models;

namespace simple_api.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, Stock stockModel);
        Task<Stock?> DeleteAsync(int id);  
        Task<bool> IsStockExist(int id);
    }
}