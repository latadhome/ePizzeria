using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ePizzeriaHub.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICatalogService _catalogService;
        private readonly IPizzeriaService _pizzeriaService;

        public HomeController(ILogger<HomeController> logger, ICatalogService catalogService, IPizzeriaService pizzeriaService)
        {
            _logger = logger;
            _catalogService = catalogService;
            _pizzeriaService = pizzeriaService;
        }

        public IActionResult Index()
        {
            ViewBag.Pizzerias = _pizzeriaService.GetPizzerias();
            var items = _catalogService.GetItems().Where(i => i.CategoryId == 1);
            return View(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}