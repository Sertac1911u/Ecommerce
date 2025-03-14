using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
