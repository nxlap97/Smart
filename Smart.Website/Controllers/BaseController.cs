using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Smart.Service.Interfaces;
using Smart.Utility.StringHelper;
using Smart.Website.Extensions;

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
            var customerId = HttpContext.User.GetSpecificClaim(ClaimHelper.ID);
            var scope = _serviceProvider.CreateScope();
            var _appRoleService = scope.ServiceProvider.GetRequiredService<IAppRoleService>();
            var _httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();
            if (!string.IsNullOrWhiteSpace(customerId))
            {
                var permisions = _appRoleService.checkAccessPermision(customerId);
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
