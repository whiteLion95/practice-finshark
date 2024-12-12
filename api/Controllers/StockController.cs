using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StockController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult ReadAll()
        {
            var stocks = _context.Stocks.ToList()
                .Select(_mapper.Map<ReadStockDto>);
                
            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Read(int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ReadStockDto>(stock));
        }

        [HttpPost]
        public IActionResult Create(CreateStockDto stockDto)
        {
            var stock = _mapper.Map<Stock>(stockDto);
            _context.Stocks.Add(stock);
            _context.SaveChanges();

            return CreatedAtAction(
                nameof(Read), 
                new { id = stock.Id }, 
                _mapper.Map<ReadStockDto>(stock)
            );
        }
    }
}