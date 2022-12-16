using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : ControllerBase
    {
        // https://localhost:7288/Home/Index?name=Tom&age=37
        public string Index()
        {
            string name = Request.Query["name"];
            string age = Request.Query["age"];
            return $"Name: {name}  Age: {age}";
        }

        //// https://localhost:7288/Home/Index?people=Tom&people=Bob&people=Sam
        //// https://localhost:7288/Home/Index?people[0]=Tom&people[2]=Bob&people[1]=Sam
        //// https://localhost:7288/Home/Index?[0]=Tom&[2]=Bob&[1]=Sam
        //public string Index(string[] people)
        //{
        //    string result = "";
        //    foreach (var person in people)
        //        result = $"{result}{person}; ";
        //    return result;
        //}

        //// https://localhost:7288/Home/Index?name=Tom&age=37
        //public string Index(Person person)
        //{
        //    return $"Person Name: {person.Name}  Person Age: {person.Age}";
        //}

        //public string Index(string name = "Bob", int age = 33)
        //{
        //    return $"Name: {name}  Age: {age}";
        //}

        //public string Index(string name) => $"Your name: {name}";       
    }
}