using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListDiscountFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
