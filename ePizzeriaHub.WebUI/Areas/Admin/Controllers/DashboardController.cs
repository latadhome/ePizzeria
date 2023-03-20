using Microsoft.AspNetCore.Mvc;

namespace ePizzeriaHub.WebUI.Areas.Admin.Controllers
{
    
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
