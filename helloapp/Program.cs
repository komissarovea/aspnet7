using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.Run(async (context) =>
{
    PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
    IFileInfo fileinfo = fileProvider.GetFileInfo("forest.jpg");
    // FileInfo fi =new FileInfo("forest.jpg");

    context.Response.Headers.ContentDisposition = "attachment; filename=my_forest2.jpg";
    await context.Response.SendFileAsync(fileinfo);

    //context.Response.Headers.ContentDisposition = "attachment; filename=my_forest.jpg";
    //await context.Response.SendFileAsync("forest.jpg");

    //var path = context.Request.Path;
    //var fullPath = $"html/{path}";
    //var response = context.Response;

    //response.ContentType = "text/html; charset=utf-8";
    //if (File.Exists(fullPath))
    //{
    //    await response.SendFileAsync(fullPath);
    //}
    //else
    //{
    //    response.StatusCode = 404;
    //    await response.WriteAsync("<h2>Not Found</h2>");
    //}

    //context.Response.ContentType = "text/html; charset=utf-8";
    //await context.Response.SendFileAsync("html/index.html");

    //await context.Response.SendFileAsync("D:\\forest.jpg");
    //await context.Response.SendFileAsync("forest.jpg");
});

app.Run();

//HttpRequest request = context.Request;

//context.Response.ContentType = "text/html; charset=utf-8";
//await context.Response.WriteAsync($"<p>Path: {context.Request.Path}</p>" +
//    $"<p>QueryString: {context.Request.QueryString}</p>");

//var stringBuilder = new System.Text.StringBuilder("<h3>Параметры строки запроса</h3><table>");
//stringBuilder.Append("<tr><td>Параметр</td><td>Значение</td></tr>");
//foreach (var param in context.Request.Query)
//{
//    stringBuilder.Append($"<tr><td>{param.Key}</td><td>{param.Value}</td></tr>");
//}
//stringBuilder.Append("</table>");
//await context.Response.WriteAsync(stringBuilder.ToString());

//string name = context.Request.Query["name"];
//string age = context.Request.Query["age"];
//await context.Response.WriteAsync($"{name} - {age}");

//Debug.WriteLine(request.Body);
//Debug.WriteLine(request.BodyReader);
//Debug.WriteLine(request.ContentLength);
//Debug.WriteLine(request.ContentType);
//Debug.WriteLine(request.Cookies);
//// Debug.WriteLine(request.Form);
//Debug.WriteLine(request.HasFormContentType);
//Debug.WriteLine(request.Headers);
//Debug.WriteLine(request.Host);
//Debug.WriteLine(request.HttpContext);
//Debug.WriteLine(request.IsHttps);
//Debug.WriteLine(request.Method);
//Debug.WriteLine(request.Path);
//Debug.WriteLine(request.PathBase);
//Debug.WriteLine(request.Protocol);
//Debug.WriteLine(request.Query);
//Debug.WriteLine(request.QueryString);
//Debug.WriteLine(request.RouteValues);
//Debug.WriteLine(request.Scheme);

//var path = context.Request.Path;
//var now = DateTime.Now;
//var response = context.Response;

//if (path == "/date")
//    await response.WriteAsync($"Date: {now.ToShortDateString()}");
//else if (path == "/time")
//    await response.WriteAsync($"Time: {now.ToShortTimeString()}");
//else
//    await response.WriteAsync("Hello METANIT.COM");

//context.Response.ContentType = "text/html; charset=utf-8";

//var acceptHeaderValue = context.Request.Headers.Accept;
//await context.Response.WriteAsync($"<br>Accept: {acceptHeaderValue}<br>");

//await context.Response.WriteAsync($"<br>Path: {context.Request.Path}<br><br>");

//var stringBuilder = new System.Text.StringBuilder("<table>");

//foreach (var header in request.Headers)
//{
//    stringBuilder.Append($"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>");
//}
//stringBuilder.Append("</table>");
//await context.Response.WriteAsync(stringBuilder.ToString());

//HttpResponse response = context.Response;
//Console.WriteLine(response.Body);
//Console.WriteLine(response.BodyWriter);
//Console.WriteLine(response.ContentLength);
//Console.WriteLine(response.ContentType);
//Console.WriteLine(response.Cookies);
//Console.WriteLine(response.HasStarted);
//Console.WriteLine(response.Headers);
//Console.WriteLine(response.Headers.Host);
//Console.WriteLine(response.HttpContext);
//Console.WriteLine(response.StatusCode);

//response.Headers.ContentLanguage = "ru-RU";
//response.Headers.ContentType = "text/plain; charset=utf-8";  // response.ContentType
//response.ContentType = "text/html; charset=utf-8";
//response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
//response.StatusCode = 404;
//await response.WriteAsync("Привет METANIT.COM", System.Text.Encoding.Default);
//await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");
//response.SendFileAsync()

//int x = 2;
//int y = 1;
//app.Run(async (context) =>
//{
//    x = x * 2;  //  2 * 2 = 4
//    y++;
//    await context.Response.WriteAsync($"Result: 2^{y} = {x}");
//});

//app.Run(HandleRequst);
//async Task HandleRequst(HttpContext context)
//{
//    await context.Response.WriteAsync("Hello METANIT.COM 2");
//}
//app.UseWelcomePage();
//app.MapGet("/",
//    (HttpContext context) =>
//    {
//        return "Hello World!";
//    });


//var acceptLanguages = context.Request.GetTypedHeaders().AcceptLanguage.OrderByDescending(x => x.Quality ?? 1);
//var requestCulture = context.Features.Get<IRequestCultureFeature>();
//Console.WriteLine(context.Connection);
//Console.WriteLine(context.Features);
//Console.WriteLine(context.Items);
//Console.WriteLine(context.Request);
//Console.WriteLine(context.RequestAborted);
//Console.WriteLine(context.RequestServices);
//Console.WriteLine(context.Response);
////Console.WriteLine(context.Session);
//Console.WriteLine(context.TraceIdentifier);
//Console.WriteLine(context.User);
//Console.WriteLine(context.WebSockets);

// WebApplicationOptions options = new WebApplicationOptions() { Args = args };
//builder.Configuration
//builder.Environment
//builder.Host
//builder.Logging
//builder.Services
//builder.WebHost

//IHost host = app;
//IApplicationBuilder applicationBuilder = app;
//IEndpointRouteBuilder endpointRouteBuilder = app;

//app.Configuration
//app.Environment
//app.Lifetime
//app.Logger
//app.Services
//app.Urls

//app.RunAsync();
//app.Start();
//app.StartAsync();
//app.StopAsync();

