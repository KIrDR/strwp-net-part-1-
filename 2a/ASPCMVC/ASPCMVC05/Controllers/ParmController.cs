using ASPCMVC05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC05.Controllers
{
    public class ParmController : Controller
    {
        private readonly ILogger<ParmController> _logger;

        public ParmController(ILogger<ParmController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        public IActionResult Uri01(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri02(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri03(float id)
        {
            ViewBag.Id = id;
            return View();
        }
        public IActionResult Uri04(DateTime id)
        {
            ViewBag.Id = id;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}