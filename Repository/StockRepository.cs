using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_api.Data;
using simple_api.Dtos.Stock;
using simple_api.interfaces;
using simple_api.Models;

namespace simple_api.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> Createasync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockModel == null) {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateStockRequestDto)
        {
            var stockForUpdate = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (stockForUpdate == null) {
                return null;
            }

            stockForUpdate.Symbol = updateStockRequestDto.Symbol;
            stockForUpdate.CompanyName = updateStockRequestDto.CompanyName;
            stockForUpdate.Purchase = updateStockRequestDto.Purchase;
            stockForUpdate.LastDiv = updateStockRequestDto.LastDiv;
            stockForUpdate.Industry = updateStockRequestDto.Industry;
            stockForUpdate.MarketCap = updateStockRequestDto.MarketCap;

            await _context.SaveChangesAsync();

            return stockForUpdate;
        }
    }
}