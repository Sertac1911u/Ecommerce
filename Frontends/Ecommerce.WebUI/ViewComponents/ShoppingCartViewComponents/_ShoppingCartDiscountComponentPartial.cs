using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
