using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Smart.Service.Interfaces;
using Smart.Website.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smart.Website.Areas.Admin.Controllers
{
    public class CustomerController : AdminController
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerService _customerService;
        private readonly IViewEnginerService _viewEngineService;
        public CustomerController(IConfiguration configuaration, ICustomerService customerService, IViewEnginerService viewEngineService)
        {
            _configuration = configuaration;
            _customerService = customerService;
            _viewEngineService = viewEngineService;
        }

        public IActionResult GetCustomers()
        {
            var model = _customerService.GetCustomers();
            return View(model);
        }
    }
}
