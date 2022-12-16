using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    //[NonController]
    public class HomeController : ControllerBase
    {
        public async Task Index()
        {
            var ctx1 = ControllerContext.HttpContext;
            var ctx2 = HttpContext;
            bool b = ctx1 == ctx2;
            b = ctx2.Request == Request;
            b = ctx2.Response == Response;

            Response.ContentType = "text/html;charset=utf-8";
            //await Response.WriteAsync("<h2>Hello METANIT.COM</h2>");
            System.Text.StringBuilder tableBuilder = new("<h2>Request headers</h2><table>");
            foreach (var header in Request.Headers)
            {
                tableBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
            }
            tableBuilder.Append("</table>");
            await Response.WriteAsync(tableBuilder.ToString());
        }

        //[ActionName("Index")]
        [HttpHead, HttpOptions, HttpPost, HttpPatch, HttpPut,  HttpDelete]
        public string Hello()
        {
            return "Hello ASP.NET";
        }

        [HttpPost, HttpOptions]
        public string Hello2() => "Hello 22";

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