using Microsoft.AspNetCore.Mvc;
using PAW2.Business;
using PAW2.Models.ViewModels;

namespace PAW2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly BusinessCategory _business = new();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _business.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("modifiedBy-not-system")]
        public async Task<IActionResult> GetNotModifiedBySystem()
        {
            var items = await _business.GetAllModifiedByNotSystem();
            return Ok(items);
        }

        [HttpGet("modifiedBy-admin")]
        public async Task<IActionResult> GetModifiedByAdmin()
        {
            var items = await _business.GetAllModifiedByAdmin();
            return Ok(items); 
        }

        [HttpGet("lastModified-null-not-admin")]
        public async Task<IActionResult> GetLastModifiedNullAndNotAdmin()
        {
            var items = await _business.GetAllWithNullLastModifiedAndNotAdmin();
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
        public async Task<IActionResult> Create([FromBody] CategoryViewModel model)
        {
            var result = await _business.CreateAsync(model);
            return Ok(result);
        }


    }
}
