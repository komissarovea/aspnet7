using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : Controller
    {
        public IActionResult Index() => Content("Index");
        public IActionResult About() => Content("About");

        public IActionResult Contact2()
        {
            return LocalRedirect("~/Home/About");

            //return RedirectPermanent("~/Home/About");
            //return Redirect("https://microsoft.com");
            //return Redirect("~/Home/About");
        }
    }

}