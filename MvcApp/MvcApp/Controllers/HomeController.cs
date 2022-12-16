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

        public IActionResult GetFile()
        {
            // Путь к файлу
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            // Тип файла - content-type
            string file_type = "text/plain";
            // Имя файла - необязательно
            string file_name = "hello.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }

        public IActionResult GetBytes()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            byte[] mas = System.IO.File.ReadAllBytes(path);
            string file_type = "text/plain";
            string file_name = "hello2.txt";
            return File(mas, file_type, file_name);
        }

        // Отправка потока
        public IActionResult GetStream()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/hello.txt");
            FileStream fs = new FileStream(path, FileMode.Open);
            string file_type = "text/plain";
            string file_name = "hello3.txt";
            return File(fs, file_type, file_name);
        }

        public IActionResult GetVirtualFile() => File("Files/hello.txt", "text/plain", "hello4.txt");
    }

}