using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Website.Areas.Admin.Controllers
{
    public class ProductController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
