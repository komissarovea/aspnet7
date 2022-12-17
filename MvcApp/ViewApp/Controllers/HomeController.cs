using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ViewApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public string Index(bool isMarried, string color, string language)
        {
            return $"isMarried: {isMarried} color: {color} Language: {language}";
        }

        public IActionResult About() => View();

        public IActionResult Hello()
        {
            return PartialView();
        }
    }
}
