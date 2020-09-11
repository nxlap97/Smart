using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart.Domain.Enums;
using Smart.Service.Models;
using Smart.Utility.Extensions;
using Smart.Utility.StringHelper;
using Smart.Website.Areas.Admin.Models;

namespace Smart.Website.Areas.Admin.Controllers
{
    public class PermisionController : AdminController
    {
        public IActionResult Index()
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            var controllerList = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(NamespaceHelper.ControllerCustomer) && !type.IsNotPublic)
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
    }
}
