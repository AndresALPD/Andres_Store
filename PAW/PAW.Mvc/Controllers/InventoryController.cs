using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
	public class InventoryController : Controller
	{
		private readonly InventoryService _service;

		public InventoryController()
		{
			_service = new InventoryService();
		}

		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View(new InventoryViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(InventoryViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.CreateAsync(model);
			TempData["Success"] = "Inventory created successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(InventoryViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.UpdateAsync(model.InventoryId, model);
			TempData["Success"] = "Inventory updated successfully.";
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
			TempData["Success"] = "Inventory deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
