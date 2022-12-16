using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    //[NonController]
    public class HomeController : ControllerBase
    {
        //[NonAction]
        [HttpPost]
        public string Index()
        {
            return "Hello METANIT.COM";
        }

        [ActionName("Index")]
        [HttpHead, HttpOptions, HttpGet, HttpPost, HttpPatch, HttpPut,  HttpDelete]
        public string Hello()
        {
            return "Hello ASP.NET";
        }

        [HttpPost, HttpOptions]
        public string Hello2() => null;

        protected internal string Hello3() => "Hello 333";


        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}