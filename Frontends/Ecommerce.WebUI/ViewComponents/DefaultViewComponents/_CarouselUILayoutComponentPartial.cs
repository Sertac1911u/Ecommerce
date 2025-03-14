using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselUILayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
