using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : ControllerBase
    {
        public Message Index() => new Message("Hello METANIT.COM");

        public record class Message(string Text);

        public void GetVoid()
        {

        }
    }

}