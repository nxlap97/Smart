using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Smart.Website.Controllers.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        public HeaderViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
