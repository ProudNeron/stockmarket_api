using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Extensions;
using SimpleAPI.interfaces;
using SimpleAPI.Models;
using static SimpleAPI.Constants.StatusConstants;

namespace SimpleAPI.Controllers
{
    [Route("api/portfolio")]
    public class PortfolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly IFMPService _fmpService;
        public PortfolioController(UserManager<AppUser> userManager,
        IStockRepository stockRepository, IPortfolioRepository portfolioRepository,
        IFMPService fmpService)
        {
            _stockRepository = stockRepository;
            _userManager = userManager;
            _portfolioRepository = portfolioRepository;
            _fmpService = fmpService;
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortfolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            return Ok(userPortfolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortfolio(string symbol)
        {
            var userName = User.GetUsername();
            var appUser =  await _userManager.FindByNameAsync(userName);
            var stock = await _stockRepository.GetBySymbolAsync(symbol);

            if (stock == null)
            {
                stock = await _fmpService.FindStockBySymbolAsync(symbol);

                if (stock == null)
                {
                    return BadRequest("Stock doesn't exist");
                }

                await _stockRepository.CreateAsync(stock);
            }

            if (stock == null)
            {
                return BadRequest("Stock not found");
            }

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            if (userPortfolio.Any(p => p.Symbol.ToLower() == symbol.ToLower()))
            {
                BadRequest("Cannot add the same stock to portfolio");
            }

            var newPortfolioModel = new Portfolio
            {
                StockId = stock.Id,
                AppUserId = appUser.Id
            };

            await _portfolioRepository.CreatePortfolioAsync(newPortfolioModel);

            if (newPortfolioModel == null)
            {
                return StatusCode(STATUS_CODE_500, "Could not create");
            }

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortfolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);

            var userPortfolio = await _portfolioRepository.GetUserPortfolioAsync(appUser);

            var filteredStock = userPortfolio
                .Where(p => p.Symbol.ToLower() == symbol.ToLower()).ToList();

            if (filteredStock.Count() != 1)
            {
                return BadRequest("Stock isn't in your portfolio");
            }

            await _portfolioRepository.DeletePortfolioAsync(appUser, symbol);

            return Ok();
        }
    }
}