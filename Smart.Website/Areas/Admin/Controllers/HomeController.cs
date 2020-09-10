using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Smart.Website.Areas.Admin.Controllers
{
    
    public class HomeController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
