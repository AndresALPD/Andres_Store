using Microsoft.AspNetCore.Mvc;
using PAW2.Business;
using PAW2.Models.ViewModels;

namespace PAW2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly BusinessProduct _business = new();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _business.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("missing-supplier")]
        public async Task<IActionResult> GetProductsWithoutSupplier()
        {
            var items = await _business.GetWithMissingSupplierAsync();
            return Ok(items);
        }

        [HttpGet("missing-inventory")]
        public async Task<IActionResult> GetProductsWithoutInventory()
        {
            var items = await _business.GetWithMissingInventoryAsync();
            return Ok(items);
        }

        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated()
        {
            var product = await _business.GetTopRatedProductAsync();
            return Ok(product);
        }

        [HttpGet("lowest-rated")]
        public async Task<IActionResult> GetLowestRated()
        {
            var product = await _business.GetLowestRatedProductAsync();
            return Ok(product);
        }

        [HttpGet("most-common-rating")]
        public async Task<IActionResult> GetMostCommonRating()
        {
            var items = await _business.GetMostCommonRatingProductsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _business.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductViewModel model)
        {
            var result = await _business.CreateAsync(model);
            return Ok(result);
        }

    }
}
