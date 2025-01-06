using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.Data;
using SimpleAPI.Dtos.Stock;
using SimpleAPI.Helpers;
using SimpleAPI.interfaces;
using SimpleAPI.Models;

namespace SimpleAPI.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockModel == null) {
                return null;
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks = _context.Stocks.Include(c => c.Comments).ThenInclude(s => s.AppUser)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy)) {
                if (query.SortBy.Equals("CompanyName", StringComparison.OrdinalIgnoreCase)) {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.CompanyName)
                        : stocks.OrderByDescending(s => s.CompanyName);
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(s => s.Comments).ThenInclude(s => s.AppUser)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Stock?> GetBySymbolAsync(string symbol)
        {
            return await _context.Stocks.FirstOrDefaultAsync(s => s.Symbol == symbol);
        }

        public Task<bool> IsStockExist(int id)
        {
            return _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, Stock stockModel)
        {
            var stockForUpdate = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stockForUpdate == null) {
                return null;
            }

            stockForUpdate.Symbol = stockModel.Symbol;
            stockForUpdate.CompanyName = stockModel.CompanyName;
            stockForUpdate.Purchase = stockModel.Purchase;
            stockForUpdate.LastDiv = stockModel.LastDiv;
            stockForUpdate.Industry = stockModel.Industry;
            stockForUpdate.MarketCap = stockModel.MarketCap;

            await _context.SaveChangesAsync();

            return stockForUpdate;
        }
    }
}