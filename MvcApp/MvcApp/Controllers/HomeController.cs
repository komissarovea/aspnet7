﻿using Microsoft.AspNetCore.Mvc;
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
            return new HtmlResult("<h2>Hello METANIT.COM!</h2>");
        }

        public ActionResult GetVoid1()
        {
            return new EmptyResult();
        }
    }

}