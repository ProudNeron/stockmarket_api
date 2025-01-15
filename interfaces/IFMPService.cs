using SimpleAPI.Models;

namespace SimpleAPI.interfaces
{
    public interface IFMPService
    {
        Task<Stock> FindStockBySymbolAsync(string symbol);
    }
}