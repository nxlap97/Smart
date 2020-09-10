using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart.Domain.Enums;
using Smart.Utility.Extensions;
using Smart.Utility.StringHelper;

namespace Smart.Website.Areas.Admin.Controllers
{
    public class PermisionController : AdminController
    {
        public IActionResult Index()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var ks = asm.GetTypes();
            var lstController = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(NamespaceHelper.ControllerCustomer) && !type.IsNotPublic).ToList();
            //
            //.SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            //.Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            //.Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            //.OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            var values = Enum.GetValues(typeof(PermisionEnum)).Cast<PermisionEnum>().Select(x => new { value = (int)x, name = x.GetDescription() } );
            return View();
        }
    }
}
