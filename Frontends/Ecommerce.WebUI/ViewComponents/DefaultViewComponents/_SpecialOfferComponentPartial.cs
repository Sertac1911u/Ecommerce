﻿using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
