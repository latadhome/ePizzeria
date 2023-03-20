﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ePizzeriaHub.WebUI.Helpers
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
         public void OnAuthorization(AuthorizationFilterContext context)
        {
            if(!context.HttpContext.User.IsInRole(Roles))
            {
                context.Result = new RedirectToActionResult("UnAuthorize", "Account", new { area = "" });
            }
            //else
            //{
            //    context.Result = new RedirectToActionResult("Login", "Account", new { area = "" });
            //}
        }
    }
}
