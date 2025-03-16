using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListCategoriesFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
