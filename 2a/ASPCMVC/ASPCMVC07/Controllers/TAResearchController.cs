using ASPCMVC07.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ASPCMVC07.Controllers
{
    public class TAResearchController : Controller
    {
        private readonly ILogger<TAResearchController> _logger;

        public TAResearchController(ILogger<TAResearchController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/it/{n}/{str}")]
        [Route("/it/{n}/{str}")]
        public IActionResult GETM04(int n, string str)
        {
            ViewBag.Message = "GET:M04:/" + n + "/" + str;
            return View();
        }
        [HttpGet("/it/{b}/{letters:alpha}")]
        [Route("/it/{b}/{letters:alpha}")]
        public IActionResult GETM05(bool b, string letters)
        {
            ViewBag.Message = "GET:M05:/" + b + "/" + letters;
            return View();
        }
        [HttpPost("/it/{b}/{letters:alpha}")]
        [Route("/it/{b}/{letters:alpha}")]
        public IActionResult POSTM05(bool b, string letters)
        {
            ViewBag.Message = "POST:M05:/" + b + "/" + letters;
            return View();
        }
        [HttpGet("/it/M06/{f}/{str:minlength(2):maxlength(5)}")]
        [Route("/it/M06/{f}/{str:minlength(2):maxlength(5)}")]
        public IActionResult GETM06(float f, string str)
        {
            ViewBag.Message = "GET:M06:/" + f + "/" + str;
            return View();
        }
        [HttpDelete("/it/{f}/{str:minlength(2):maxlength(5)}")]
        [Route("/it/{f}/{str:minlength(2):maxlength(5)}")]
        public IActionResult DELETEM06(float f, string str)
        {
            ViewBag.Message = "DELETE:M06:/" + f + "/" + str;
            return View();
        }
        [HttpPut("/it/{letters:alpha:minlength(3):maxlength(4)}/{n:min(100):max(200)}")]
        [Route("/it/{letters:alpha:minlength(3):maxlength(4)}/{n:min(100):max(200)}")]
        public IActionResult PUTM07(string letters, int n)
        {
            ViewBag.Message = "PUT:M07:/" + letters + "/" + n;
            return View();
        }
        [HttpPost("/it/{mail}")]
        [Route("/it/{mail}")]
        public IActionResult POSTM08([RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")] string mail)
        {
            ViewBag.Message = "POST:M08:/" + mail;
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