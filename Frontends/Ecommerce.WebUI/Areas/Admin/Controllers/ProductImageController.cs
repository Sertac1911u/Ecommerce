using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.Areas.Admin.Controllers
{
    public class ProductImageController : Controller
    {
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            return View();
        }
    }
}
