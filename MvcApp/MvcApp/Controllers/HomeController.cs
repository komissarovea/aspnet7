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
            Person tom = new Person("Tom", 37);

            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // учитываем регистр
                WriteIndented = true                // отступы для красоты
            };
            return Json(tom, jsonOptions);

            //return Content("Hello METANIT.COM");

            //return new ObjectResult(new Person("Tom", 37));
            //return new NoContentResult();
            //return new ContentResult() { Content = "<h2>Hello METANIT.COM!</h2>" };
        }

        //public JsonResult GetName()
        //{
        //    return Json("Tom");
        //}
    }

}