using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    //[NonController]
    public class HomeController : ControllerBase
    {
        [NonAction]
        public string Index()
        {
            return "Hello METANIT.COM";
        }

        [ActionName("Index")]
        public string Hello()
        {
            return "Hello ASP.NET";
        }

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