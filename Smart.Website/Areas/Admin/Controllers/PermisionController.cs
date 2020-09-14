using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Smart.Domain.Enums;
using Smart.Service.Interfaces;
using Smart.Service.Models;
using Smart.Utility.Extensions;
using Smart.Utility.StringHelper;
using Smart.Website.Areas.Admin.Models;
using Smart.Website.Services;

namespace Smart.Website.Areas.Admin.Controllers
{
    public class PermisionController : AdminController
    {
        private readonly IConfiguration _configuration;
        private readonly IAppRoleService _roleService;
        private readonly IViewEnginerService _viewEngineService;
        public PermisionController(IConfiguration configuaration, IAppRoleService roleService, IViewEnginerService viewEngineService)
        {
            _configuration = configuaration;
            _roleService = roleService;
            _viewEngineService = viewEngineService;
        }
        public IActionResult Index()
        {
            var controllerExcepts = _configuration.GetValue<string>("Permisions:ExceptsController")?.Split(",").ToList();
            var Namespace = _configuration.GetValue<string>("Permisions:NamespaceCustomer");

            Assembly asm = Assembly.GetExecutingAssembly();

            var controllerList = asm.GetTypes().Where( type => typeof(Controller).IsAssignableFrom(type) 
                                                        && (string.IsNullOrWhiteSpace(Namespace) || type.Namespace.Contains(Namespace)) 
                                                        && !controllerExcepts.Contains(type.Name)
                                                        && !type.IsNotPublic)
             .Select(x => new ControllerModel()
             {
                 ActionList = x.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Select(y => new ActionModel { Name = y.Name }).ToList(),
                 Name = x.Name
             }).ToList();

            var model = new PermisionModel()
            {
                RoleList = Enum.GetValues(typeof(PermisionEnum)).Cast<PermisionEnum>().Select(y => new SelectionModel() { Value = ((int)y).ToString(), Name = y.GetDescription() }).OrderBy(r=>r.Value).ToList(),
                ControllerList = controllerList
            };

            return View(model);
        }

        public IActionResult RoleList()
        {
            var model = _roleService.GetRoles();

            return View(model);
        }

        [HttpPost]
        public IActionResult PermisionList(string roleId)
        {
            var controllerExcepts = _configuration.GetValue<string>("Permisions:ExceptsController")?.Split(",").ToList();
            var Namespace = _configuration.GetValue<string>("Permisions:NamespaceCustomer");

            Assembly asm = Assembly.GetExecutingAssembly();

            var controllerList = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)
                                                       && (string.IsNullOrWhiteSpace(Namespace) || type.Namespace.Contains(Namespace))
                                                       && !controllerExcepts.Contains(type.Name)
                                                       && !type.IsNotPublic)
             .Select(x => new ControllerModel()
             {
                 ActionList = x.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Select(y => new ActionModel { Name = y.Name }).ToList(),
                 Name = x.Name
             }).ToList();

            var model = new PermisionModel()
            {
                RoleList = Enum.GetValues(typeof(PermisionEnum)).Cast<PermisionEnum>().Select(y => new SelectionModel() { Value = ((int)y).ToString(), Name = y.GetDescription() }).OrderBy(r => r.Value).ToList(),
                ControllerList = controllerList
            };
            var render = _viewEngineService.RenderPartialToStringAsync("~/Areas/Admin/Views/Permision/_PermisionListPartial.cshtml", model);
            return Json(new { status = true, html = render.Result });
        }
    }
}
