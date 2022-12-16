using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using MvcApp.Models;
using System.Diagnostics;

namespace MvcApp.Controllers
{
    public record class Person(string Name, int Age);

    public class HomeController : ControllerBase
    {
        public async Task Index()
        {
            string form = @"
<form method='post'>
   <p><input name='[0]' /></p>
    <p><input name='[2]' /></p>
    <p><input name='[1]' /></p>
    <input type='submit' value='Send' />
</form>
";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(form);
        }
        [HttpPost]
        public string Index(string[] names)
        {
            string result = "";
            foreach (string name in names)
            {
                result = $"{result} {name}";
            }
            return result;
        }


        //[HttpGet]
        //public async Task Index()
        //{
        //    string content = @"<form method='post'>
        //        <label>Name:</label><br />
        //        <input name='name' /><br />
        //        <label>Age:</label><br />
        //        <input type='number' name='age' /><br />
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(content);
        //}

        //[HttpPost]
        //public string Index(Person person) => $"{person.Name}: {person.Age}";

        ////[HttpPost]
        ////public string Index(string name, int age) => $"{name}: {age}";
    }

}