using ASPCMVC04.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPCMVC04.Controllers
{
    public class StatusController : Controller
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Status/Index";
            return View();
        }
        [Route("Status/S200")]        
        public IActionResult S200()
        {
            ViewBag.Message = "Status/S200";
            return StatusCode(200);
        }
        [Route("Status/S300")]
        public IActionResult S300()
        {
            ViewBag.Message = "Status/S300";
            return StatusCode(300);
        }
        [Route("Status/S500")]
        public IActionResult S500()
        {
            ViewBag.Message = "Status/S500";
            return StatusCode(500);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}