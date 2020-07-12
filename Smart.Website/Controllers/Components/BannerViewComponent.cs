using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Smart.Website.Controllers.Components
{
    public class BannerViewComponent : ViewComponent
    {
        public BannerViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
