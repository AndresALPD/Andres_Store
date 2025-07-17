using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
	public class SupplierController : Controller
	{
		private readonly SupplierService _service;

		public SupplierController()
		{
			_service = new SupplierService();
		}

		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View(new SupplierViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(SupplierViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.CreateAsync(model);
			TempData["Success"] = "Supplier created successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(SupplierViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.UpdateAsync(model.SupplierId, model);
			TempData["Success"] = "Supplier updated successfully.";
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
			TempData["Success"] = "Supplier deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
