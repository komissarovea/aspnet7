using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    record class Error(string Message);

    public class HomeController : Controller
    {
        readonly ITimeService timeService;

        public HomeController(ITimeService timeServ)
        {
            timeService = timeServ;
        }

        //public string Index() => timeService.Time;

        //public string Index([FromServices] ITimeService timeService2)
        //{
        //    return timeService2.Time;
        //}

        public string Index()
        {
            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time ?? "Undefined";
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Controller: {context.Controller.GetType().Name}");
            Console.WriteLine($"Action: {context.ActionDescriptor.DisplayName}");

            base.OnActionExecuting(context);
        }
    }

}