using Microsoft.AspNetCore.Mvc;

namespace ViewApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //ViewData["Message"] = "Hello METANIT.COM";
            ViewBag.Message = "Hello METANIT.COM";

            var people = new List<string> { "Tom", "Sam", "Bob" };
            return View(people);
        }
    }
}
