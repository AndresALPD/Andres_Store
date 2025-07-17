using Microsoft.AspNetCore.Mvc;
using PAW2.Business;
using PAW2.Models.ViewModels;

namespace PAW2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogTaskController : ControllerBase
    {
        private readonly BusinessCatalogTask _business = new();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _business.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _business.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CatalogTaskViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _business.CreateAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CatalogTaskController] Error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
