using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            List<Claim> claims = new List<Claim>
             {
                 new Claim(ClaimHelper.ID, result.Object.Id),
                 new Claim(ClaimHelper.USERNAME, result.Object.UserName)
             };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(principal),
                    new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                    });

            var userId = HttpContext.User.GetSpecificClaim(ClaimHelper.ID);

            return Redirect(model.RequestPath ?? "/");
        }

        [HttpGet]
        [Route("dang-xuat.html")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}