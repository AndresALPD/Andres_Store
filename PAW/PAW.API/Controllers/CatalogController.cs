using Microsoft.AspNetCore.Mvc;
using PAW2.Business;
using PAW2.Models.ViewModels;

namespace PAW2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        private readonly BusinessCatalog _business = new();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _business.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _business.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CatalogViewModel model)
        {
            var result = await _business.CreateAsync(model);
            return Ok(result);
        }

    }
}
