using ASPCMVC03.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC03.Controllers
{
    public class StartController : Controller
    {
        private readonly ILogger<StartController> _logger;

        public StartController(ILogger<StartController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Start/Index";
            return View();
        }

        [Route("Start/One")]
        public IActionResult One()
        {
            ViewBag.Message = "Start/One";
            return View();
        }
        [Route("Start/Two")]
        public IActionResult Two()
        {
            ViewBag.Message = "Start/Two";
            return View();
        }
        [Route("Start/Three")]
        public IActionResult Three()
        {
            ViewBag.Message = "Start/Three";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}