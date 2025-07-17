using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
	public class CatalogController : Controller
	{
		private readonly CatalogService _service;

		public CatalogController()
		{
			_service = new CatalogService();
		}

		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View(new CatalogViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(CatalogViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.CreateAsync(model);
			TempData["Success"] = "Catalog created successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(CatalogViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.UpdateAsync(model.Identifier, model);
			TempData["Success"] = "Catalog updated successfully.";
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
			TempData["Success"] = "Catalog deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
