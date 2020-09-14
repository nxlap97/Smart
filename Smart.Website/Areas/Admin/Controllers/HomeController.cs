using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Smart.Core.Domain;
using Smart.Service.Interfaces;

namespace Smart.Website.Areas.Admin.Controllers
{
    
    public class HomeController : AdminController
    {
        private readonly IAppRoleService _roleService;
        public HomeController(IAppRoleService roleService)
        {
            _roleService = roleService;
        }
        public IActionResult Index()
        {
           

            return View();
        }
    }
}
