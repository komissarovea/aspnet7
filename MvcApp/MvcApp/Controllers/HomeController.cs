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
            string content = @"<form method='post' 
                    enctype='multipart/form-data'
                    action='/Home/PersonData'>
                   <label>Name:</label><br />
                <input name='name' /><br />
                <label>Age:</label><br />
                <input type='number' name='age' /><br />
                <input type='submit' value='Send' />
            </form>";
            Response.ContentType = "text/html;charset=utf-8";
            await Response.WriteAsync(content);
        }

        [HttpPost]
        public string PersonData()
        {
            string name = Request.Form["name"];
            string age = Request.Form["age"];
            return $"{name}: {age}";
        }

        //public async Task Index()
        //{
        //    string form = @"<form method='post'>
        //        <p>
        //            Person1 Name:<br/> 
        //            <input name='people[0].name' /><br/>
        //            Person1 Age:<br/>
        //            <input name='people[0].age' />
        //        </p>
        //        <p>
        //            Person2 Name:<br/> 
        //            <input name='people[1].name' /><br/>
        //            Person2 Age:<br/>
        //            <input name='people[1].age' />
        //        </p>
        //        <input type='submit' value='Send' />
        //    </form>";
        //    Response.ContentType = "text/html;charset=utf-8";
        //    await Response.WriteAsync(form);
        //}

        //[HttpPost]
        //public string Index(Person[] people)
        //{
        //    string result = "";
        //    foreach (Person person in people)
        //    {
        //        result = $"{result} \n{person}";
        //    }
        //    return result;
        //}

        //    [HttpGet]
        //    public async Task Index()
        //    {
        //        string content = @"<form method='post'>
        //    <p>
        //        Германия:
        //        <input type='text' name='items[germany]' />
        //    </p>
        //    <p>
        //        Франция:
        //        <input type='text' name='items[france]' />
        //    </p>
        //    <p>
        //        Испания:
        //        <input type='text' name='items[spain]' />
        //    </p>
        //    <p>
        //        <input type='submit' value='Отправить' />
        //    </p>
        //</form>";
        //        Response.ContentType = "text/html;charset=utf-8";
        //        await Response.WriteAsync(content);
        //    }

        //    [HttpPost]
        //    public string Index(Dictionary<string, string> items)
        //    {
        //        string result = "";
        //        foreach (var item in items)
        //        {
        //            result = $"{result} {item.Key} - {item.Value}; ";
        //        }
        //        return result;
        //    }

        //        public async Task Index()
        //        {
        //            string form = @"
        //<form method='post'>
        //    <p><input name='names[0]' /></p>
        //    <p><input name='names[2]' /></p>
        //    <p><input name='names[1]' /></p>
        //    <input type='submit' value='Send' />
        //</form>
        //";
        //            Response.ContentType = "text/html;charset=utf-8";
        //            await Response.WriteAsync(form);
        //        }
        //        [HttpPost]
        //        public string Index(string[] names)
        //        {
        //            string result = "";
        //            foreach (string name in names)
        //            {
        //                result = $"{result} {name}";
        //            }
        //            return result;
        //        }

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