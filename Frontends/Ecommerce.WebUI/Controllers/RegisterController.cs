using Ecommerce.DtoLayer.IdentityDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Ecommerce.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {

            var client = _httpClientFactory.CreateClient();

            // Option 1: Use PostAsJsonAsync correctly
            var response = await client.PostAsJsonAsync("http://localhost:5001/api/Registers", createRegisterDto);

            // OR Option 2: Use PostAsync with StringContent
            // var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            // StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            // var response = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                // Log the error or add to model state
                ViewBag.ErrorMessage = $"API Error: {response.StatusCode} - {errorContent}";
            }
            return View();
        }
    }
}
