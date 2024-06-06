using laba_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace laba_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/SAI")] // Указываем маршрут
        public IActionResult Index(string ParmA, string ParmB)
        {
            string responseText = $"GET-Http-DKA:ParmA = {ParmA},ParmB = {ParmB}";

            return Content(responseText, "text/plain");
        }
    }
}