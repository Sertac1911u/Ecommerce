﻿using Ecommerce.Catalog.Dtos.FeatureSliderDtos;
using Ecommerce.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Catalog.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController : ControllerBase
    {
        private readonly IFeatureSliderService _FeatureSliderService;

        public FeatureSlidersController(IFeatureSliderService FeatureSliderService)
        {
            _FeatureSliderService = FeatureSliderService;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await _FeatureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await _FeatureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _FeatureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("FeatureSlider Added");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _FeatureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("FeatureSlider Deleted");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _FeatureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("FeatureSlider Updated");
        }
    }
}
