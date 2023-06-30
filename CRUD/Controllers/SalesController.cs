using CRUD.DTO;
using CRUD.Models;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesService _salesService;
        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SaleDTO saleDto)
        {
            Sale sale = await _salesService.CreateAsync(saleDto);

            if (sale is null)
                return BadRequest();

            return Ok(sale);
        }

        [HttpGet]
        [Route("byDateRange")]
        public async Task<IActionResult> GetByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var sales = await _salesService.GetByDateRange(dateFrom, dateTo);

            if (!sales.Any())
                return NotFound();

            return Ok(sales);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> CancelSale(int id)
        {
            Sale sale = await _salesService.CancelSale(id);

            if (sale is null)
                return NotFound();

            return Ok(sale);
        }
    }
}
