using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.Json;

namespace Application.Filters
{
    public class BasicAuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        public BasicAuthorizeAttribute()
        {
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            AdminUser adminUser = null;
            try
            {
                string serializedAdmin = context.HttpContext.Session.GetString("User");
                if (serializedAdmin != null)
                {
                    adminUser = JsonSerializer.Deserialize<AdminUser>(serializedAdmin);
                }
                context.HttpContext.Session.SetString("User", JsonSerializer.Serialize(adminUser));
            }
            catch
            {
                adminUser = null;
            }

            if (adminUser != null && adminUser.ID > 0)
            {
                var controller = context.Controller as Controller;
                controller.ViewBag.name = adminUser.ID;
                base.OnActionExecuting(context);
            }
            else
            {
                var areaName = string.Empty;
                object area = null;
                if (context.RouteData.Values.TryGetValue("area", out area))
                {
                    areaName = area.ToString();
                }
                if (areaName != string.Empty && areaName == "En")
                {
                    context.Result = new RedirectResult("/En/Login");
                }
                else
                {
                    context.Result = new RedirectToActionResult("Index", "Login", null);
                }              
            }
        }
    }
}
