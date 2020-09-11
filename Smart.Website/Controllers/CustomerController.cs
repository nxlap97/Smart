using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Smart.Service.Interfaces;
using Smart.Service.Models;
using Smart.Utility.StringHelper;
using Smart.Website.Extensions;

namespace Smart.Website.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("dang-nhap.html")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = _customerService.CheckSignIn(model.UserName, model.Password);
            if (!result.Status)
                return View();

            // create claims
            List<Claim> claims = new List<Claim>
             {
                 new Claim(ClaimHelper.ID, result.Object.Id),
                 new Claim(ClaimHelper.USERNAME, result.Object.UserName)
                 //new Claim(ClaimHelper.IP_ADDRESS, result.Object.IPAddress)
             };

            ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in
            await HttpContext.SignInAsync(
                    scheme: "SmartSecurityScheme",
                    principal: principal,
                    properties: new AuthenticationProperties
                    {
                        //IsPersistent = true, // for 'remember me' feature
                        //ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                    }
             );

            var userId = User.GetSpecificClaim(ClaimHelper.ID);

            return Redirect(model.RequestPath ?? "/");
        }

        [HttpGet]
        [Route("dang-xuat.html")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("SmartSecurityScheme");

            return Redirect("/");
        }
    }
}