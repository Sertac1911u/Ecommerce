﻿using Ecommerce.Basket.Dtos;
using Ecommerce.Basket.LoginServices;
using Ecommerce.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService,ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Basket Saved");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Basket Deleted");
        }
    }
}
