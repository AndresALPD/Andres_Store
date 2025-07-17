using Microsoft.AspNetCore.Mvc;
using PAW2.Models.ViewModels;
using PAW2.Services;

namespace PAW2.Mvc.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserRoleService _service;

        public UserRoleController()
        {
            _service = new UserRoleService();
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View(new UserRoleViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRoleViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            await _service.CreateAsync(model);
            TempData["Success"] = "UserRole created successfully.";
            return RedirectToAction("Index");
        }

    }
}
