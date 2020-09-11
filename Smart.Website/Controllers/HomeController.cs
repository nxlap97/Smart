using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Smart.Service.Interfaces;

namespace Smart.Website.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var product = _productService.GetAll();
            return View(product);
        }
    }
}