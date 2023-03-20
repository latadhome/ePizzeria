using ePizzeriaHub.WebUI.Helpers;
using ePizzeriaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ePizzeriaHub.WebUI.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
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
