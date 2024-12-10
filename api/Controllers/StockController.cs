using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos;
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
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.ToList()
                .Select(_mapper.Map<StockDto>);
                
            return Ok(stocks);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<StockDto>(stock));
        }
    }
}