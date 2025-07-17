using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
	public class ProductController : Controller
	{
		private readonly ProductService _service;

		public ProductController()
		{
			_service = new ProductService();
		}

		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View(new ProductViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(ProductViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.CreateAsync(model);
			TempData["Success"] = "Product created successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(ProductViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.UpdateAsync(model.ProductId, model);
			TempData["Success"] = "Product updated successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _service.DeleteAsync(id);
			TempData["Success"] = "Product deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
