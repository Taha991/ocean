using Microsoft.AspNetCore.Mvc;
using oceantecsa.Interface;
using oceantecsa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oceantecsa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var sales = await _saleRepository.GetAllAsync();
            return Ok(sales);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sale = await _saleRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Sales sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _saleRepository.AddAsync(sale);

            // Change the route name and route values as needed
            return CreatedAtAction("GetByIdAsync", new { id = sale.Id }, sale);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Sales sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest();
            }

            await _saleRepository.UpdateAsync(sale);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _saleRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
