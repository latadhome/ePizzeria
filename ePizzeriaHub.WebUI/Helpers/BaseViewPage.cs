using ePizzeriaHub.Entities;
using ePizzeriaHub.WebUI.Interfaces;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ePizzeriaHub.WebUI.Helpers
{
     public abstract class BaseViewPage<TModel> : RazorPage<TModel>
      {
            [RazorInject]
            public IUserAccessor _userAccessor { get; set; }
            public User CurrentUser
            {
                get
                {
                    if (User != null)
                        return _userAccessor.GetUser();
                    else
                        return null;
                }
            }
      }
}
