using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ViewApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public string Index(bool isMarried, string color, string[] languages)
        {
            string result = $"isMarried: {isMarried} color: {color} ";

            foreach (string lang in languages)
            {
                result = $"{result} {lang};";
            }
            return result;
        }

        public IActionResult About() => View();

        public ViewResult Contact()
        {
            return View();
        }

        public IActionResult Hello()
        {
            return PartialView();
        }
    }
}
