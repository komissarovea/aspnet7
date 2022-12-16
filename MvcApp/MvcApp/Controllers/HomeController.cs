using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToRoute("default", new { controller = "Home", action = "About", name = "Tom", age = 22 });
            //return RedirectToAction("About", "Home", new { name = "Tom", age = 37 });
        }

        public IActionResult About(string name, int age) => Content($"Name:{name}  Age: {age}");

        public IActionResult Contact2()
        {
            return LocalRedirect("~/Home/About");

            //return RedirectPermanent("~/Home/About");
            //return Redirect("https://microsoft.com");
            //return Redirect("~/Home/About");
        }
    }

}