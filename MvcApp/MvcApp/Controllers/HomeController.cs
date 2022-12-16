using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {

            //return new ObjectResult(new Person("Tom", 37));
            return new NoContentResult();
            //return new ContentResult() { Content = "<h2>Hello METANIT.COM!</h2>" };
        }

        public ActionResult GetVoid1()
        {
            return new EmptyResult();
        }
    }

}