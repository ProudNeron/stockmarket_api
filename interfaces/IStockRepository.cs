using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_api.Dtos.Stock;
using simple_api.Models;

namespace simple_api.interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync();
        public Task<Stock?> GetByIdAsync(int id);
        public Task<Stock> Createasync(Stock stockModel);
        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto);
        public Task<Stock?> DeleteAsync(int id);
    }
}