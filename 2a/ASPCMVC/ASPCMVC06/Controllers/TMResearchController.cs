using ASPCMVC06.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC06.Controllers
{
    public class TMResearchController : Controller
    {
        private readonly ILogger<TMResearchController> _logger;

        public TMResearchController(ILogger<TMResearchController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Index Page";
            return View();
        }
        public IActionResult GETM01(string str)
        {
            ViewBag.Message = "GET:M01";
            ViewBag.str = str;
            return View();
        }
        public IActionResult GETM02(string str)
        {
            ViewBag.Message = "GET:M02";
            ViewBag.str = str;
            return View();
        }
        public IActionResult GETM03(string str)
        {
            ViewBag.Message = "GET:M03";
            ViewBag.str = str;
            return View();
        }
        public IActionResult GETMXX()
        {
            ViewBag.Message = "GET:MXX";
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
    }
}