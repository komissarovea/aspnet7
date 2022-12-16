using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    record class Error(string Message);

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok("Don't worry. Be happy");
        }

        //public IActionResult Index(string? name)
        //{
        //    if (string.IsNullOrEmpty(name)) return BadRequest("Name undefined");
        //    return Content($"Name: {name}");
        //}

        //public IActionResult Index(int age)
        //{
        //    if (age < 18) return Unauthorized(new Error("Access is denied"));
        //    return Content("Access is available");
        //}

        //public IActionResult Index()
        //{
        //    return NotFound("Resource not found");

        //    //return StatusCode(401);
        //}
    }

}