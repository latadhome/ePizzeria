using ePizzeriaHub.WebUI.Helpers;
using ePizzeriaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ePizzeriaHub.WebUI.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
        IUserAccessor _userAccessor;
        public BaseController(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        public BaseController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
