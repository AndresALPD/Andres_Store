using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
	public class UserController : Controller
	{
		private readonly UserService _service;

		public UserController()
		{
			_service = new UserService();
		}

		public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

		public IActionResult Create()
		{
			return View(new UserViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.CreateAsync(model);
			TempData["Success"] = "User created successfully.";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Edit(int id)
		{
			var model = await _service.GetByIdAsync(id);
			if (model == null) return NotFound();

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(UserViewModel model)
		{
			if (!ModelState.IsValid) return View(model);

			await _service.UpdateAsync(model.UserId, model);
			TempData["Success"] = "User updated successfully.";
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
			TempData["Success"] = "User deleted successfully.";
			return RedirectToAction("Index");
		}
	}
}
