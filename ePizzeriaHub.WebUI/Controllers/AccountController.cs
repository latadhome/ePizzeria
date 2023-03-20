using ePizzeriaHub.Entities;
using ePizzeriaHub.Services.Interfaces;
using ePizzeriaHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ePizzeriaHub.WebUI.Controllers
{
    /// <summary>
    /// A class for Login,LogOut, SignUp, SignOut
    /// </summary>
    public class AccountController : Controller
    {
        private IAuthenticationService _authService;

        public AccountController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Redirect User Based On Assigned Role
        /// </summary>
        /// <param name="loginModel"> Account Details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)            
        {
            if (ModelState.IsValid)
            {
                var user = _authService.AuthenticateUser(loginModel.Email, loginModel.Password);
                if(user != null) {

                   if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Pizzeria", "Pizzeria", new { area = "Admin" });
                    }
                    else if (user.Roles.Contains("User"))
                    {
                        return RedirectToAction("Dashboard", "Dashboard", new { area = "User" });
                    }
                }
            }
                return View();
        }

        /// <summary>
        /// Generate User With Specific Role Using Area Feature
        /// </summary>
        /// <param name="userModel">User Details</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SignUp(UserModel userModel)
        {
            if(ModelState.IsValid)
            {
                User user = new User
                {
                    Name = userModel.Name,
                    UserName = userModel.Email,
                    Email = userModel.Email,
                    PhoneNumber = userModel.PhoneNumber

                };
                bool result = _authService.CreateUser(user, userModel.Password);
                if(result)
                {
                    return RedirectToAction("Login");
                }
            }

            return View();
        }

        public IActionResult SignoutComplete()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _authService.SignOut();
            return RedirectToAction("Index","Home");
        }

        public IActionResult UnAuthorize()
        {
            return View();
        }
    }
}
