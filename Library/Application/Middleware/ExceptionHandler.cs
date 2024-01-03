using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Application.Middleware
{
    //controller'da herhangi bir hata olduğunda burada yakalanıyor. Bu sayede her fonksiyona try-catch eklemek zorunda kalmıyoruz.
    public class ExceptionHandler
    {
        private readonly RequestDelegate next;
        public ExceptionHandler(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerManager loggerManager)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception exception)
            {
                var controllerName = context.GetRouteData().Values["controller"];
                var actionName = context.GetRouteData().Values["action"];
                loggerManager.SetLogger(controllerName + "/" + actionName);
                loggerManager.LogException(exception);
            }
        }
    }
}
