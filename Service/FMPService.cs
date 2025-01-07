using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleAPI.Dtos.Stock;
using SimpleAPI.interfaces;
using SimpleAPI.Mappers;
using SimpleAPI.Models;

namespace SimpleAPI.Service
{
    public class FMPService : IFMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Stock> FindStockBySymbolAsync(string symbol)
        {
            try
            {
                var result = await _httpClient.GetAsync(
                $"https://financialmodelingprep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}"
                );
                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var tasks = JsonConvert.DeserializeObject<FMPStock[]>(content);
                    var stock = tasks[0];
                    if (stock == null)
                    {
                        return null;
                    }

                    return stock.ToStockFromFMP();
                }

                return null;
            }
            catch (Exception ex)
            {
                //need to add logging
                return null;
            }
        }
    }
}