using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Data;
using SimpleAPI.Mappers;
using SimpleAPI.Dtos.Stock;
using Microsoft.EntityFrameworkCore;
using SimpleAPI.interfaces;
using SimpleAPI.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleAPI.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace SimpleAPI.Controllers
{
    [Route("simple_api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var stocks = await _stockRepository.GetAllAsync(query);
            
            var stocksDto = stocks.Select(s => s.ToStockDto()).ToList();
            
            return Ok(stocksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockModel = stockDto.ToStockFromDto();
            await _stockRepository.CreateAsync(stockModel);
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto()); 
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var stockModel = await _stockRepository.UpdateAsync(id, updateStockDto.ToStockFromUpdate());

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel);  
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var stockModel = await _stockRepository.DeleteAsync(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}