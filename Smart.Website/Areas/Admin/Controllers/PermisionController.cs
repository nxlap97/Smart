using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Smart.Core.Domain;
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

            var controllerList = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)
                                                       && (string.IsNullOrWhiteSpace(Namespace) || type.Namespace.Contains(Namespace))
                                                       && !controllerExcepts.Contains(type.Name)
                                                       && !type.IsNotPublic);
            var controllerListModel = new List<ControllerModel>();

            foreach (var controller in controllerList)
            {
                var actionName = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public).Select(y => y.Name).Distinct().ToList();

                var controllerModel = new ControllerModel()
                {
                    ActionList = actionName.Select(x => new ActionModel() { Name = x }).ToList(),
                    Name = controller.Name
                };
                controllerListModel.Add(controllerModel);
            }

            var model = new PermisionViewModel()
            {
                RoleList = Enum.GetValues(typeof(PermisionEnum)).Cast<PermisionEnum>().Select(y => new SelectionModel() { Value = ((int)y).ToString(), Name = y.GetDescription() }).OrderBy(r=>r.Value).ToList(),
                ControllerList = controllerListModel
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
                 ActionList = x.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                                .Select(y=>y.Name).Distinct().Select(z => new ActionModel { Name = z }).ToList(),
                 Name = x.Name
             }).ToList();

            var model = new PermisionViewModel()
            {
                RoleId = roleId,
                RoleList = Enum.GetValues(typeof(PermisionEnum)).Cast<PermisionEnum>()
                                .Select(y => new SelectionModel() { Value = ((int)y).ToString(), Name = y.GetDescription() })
                                .OrderBy(r => r.Value).ToList(),
                ControllerList = controllerList,
                RoleGroups = _roleService.GetRoleGroups(roleId)?.Select(x=> new RoleGroupViewModel() { 
                                    ActionName  = x.ActionName,
                                    ControllerName = x.ControllerName,
                                    Id =x.Id,
                                    PermisionEnumId = x.Type
                            }).ToList(),
            };
            var render = _viewEngineService.RenderPartialToStringAsync("~/Areas/Admin/Views/Permision/_PermisionListPartial.cshtml", model);
            return Json(new { status = true, html = render.Result });
        }

        [HttpPost] 
        public IActionResult UpdateRolePermision(string JsonPost)
        {
            var model = JsonConvert.DeserializeObject<List<RoleGroupViewModel>>(JsonPost);
            var lstRole = new List<RoleGroup>();
            var roleId = "";
            model.ForEach(x =>
            {
                var roleGroup = new RoleGroup()
                {
                    ActionName = x.ActionName,
                    ControllerName = x.ControllerName,
                    RoleId = x.Id,
                    Type = x.PermisionEnumId, 
                };
                lstRole.Add(roleGroup);
                roleId = x.Id;
            });

            if(!string.IsNullOrWhiteSpace(roleId))
                _roleService.DeleteRoleGroups(roleId);

            _roleService.InsertRoleGroups(lstRole);
            return Json(new { status = true, message = "" });
        }

        [HttpPost]
        public IActionResult GetUserRoles(string customerId)
        {
            var model = new CustomerRoleViewModel()
            {
                Roles = _roleService.GetRoles(),
                UserRoles = _roleService.GetUserRoles(customerId),
                CustomerId = customerId
            };
            var render = _viewEngineService.RenderPartialToStringAsync("~/Areas/Admin/Views/Permision/_RoleListPartial.cshtml", model);
            return Json(new { status = true, html = render.Result });
        }

        [HttpPost]
        public IActionResult UpdateCustomerRole(string JsonPost, string customerId)
        {
            var model = JsonConvert.DeserializeObject<List<UserRole>>(JsonPost);

            if (!string.IsNullOrWhiteSpace(customerId))
                _roleService.DeleteCustomerRoles(customerId);

            _roleService.InsertCustomerRoles(model);
            return Json(new { status = true, message = "" });
        }
    }
}
