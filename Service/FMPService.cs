using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleAPI.interfaces;
using SimpleAPI.Models;

namespace SimpleAPI.Service
{
    public class FMPService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public FMPService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        // public Task<Stock> FindStockBySymbolAsync(string symbol)
        // {
        //     // try
        //     // {
        //     //     var result = await _httpClient.GetAsync(
        //     //         $"https://financialmodelingrep.com/api/v3/profile/{symbol}?apikey={_config["FMPKey"]}");
        //     //     if (result.IsSuccessStatusCode)
        //     //     {
        //     //         var content = await result.Content.ReadAsStringAsync();
        //     //     }
        //     // }
        //     // catch (Exception ex)
        //     // {

        //     // }
        // }
    }
}