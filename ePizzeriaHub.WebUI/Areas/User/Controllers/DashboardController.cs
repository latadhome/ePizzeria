using ePizzeriaHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ePizzeriaHub.WebUI.Areas.User.Controllers
{
    
    public class DashboardController : BaseController
    {
        private readonly IPizzeriaService _pizzeriaService;
        private readonly ICatalogService _catalogService;

        public DashboardController(IPizzeriaService pizzeriaService, ICatalogService catalogService)
        {
            _pizzeriaService = pizzeriaService;
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            ViewBag.Pizzerias = _pizzeriaService.GetPizzerias();
            var items = _catalogService.GetItems().Where(i => i.CategoryId == 1);
            return View(items);
        }

        public IActionResult Dashboard()
        {
            ViewBag.Pizzerias = _pizzeriaService.GetPizzerias();
            var items = _catalogService.GetItems().Where(i => i.CategoryId == 1);
            return View(items);
        }
    }
}
