using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Smart.Service.Interfaces;

namespace Smart.Website.Controllers
{
    public class BaseController : Controller
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //after into action
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["Controller"].ToString().ToLower();
            var action = context.RouteData.Values["Action"].ToString().ToLower();
            using (var scope = _serviceProvider.CreateScope())
            {
                var result = scope.ServiceProvider.GetRequiredService<IAppRoleService>();
                var roles = result.GetRoles();
            }

            //context.HttpContext.Response.Redirect("/dang-nhap.html");

            //context.Result = NoContent();
            //base.OnActionExecuting(context);
        }

        //before action
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }
    }
}
