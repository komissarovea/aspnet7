WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.Run(async (context) =>
{
    HttpResponse response = context.Response;
    Console.WriteLine(response.Body);
    Console.WriteLine(response.BodyWriter);
    Console.WriteLine(response.ContentLength);
    Console.WriteLine(response.ContentType);
    Console.WriteLine(response.Cookies);
    Console.WriteLine(response.HasStarted);
    Console.WriteLine(response.Headers);
    Console.WriteLine(response.Headers.Host);
    Console.WriteLine(response.HttpContext);
    Console.WriteLine(response.StatusCode);

    response.Headers.ContentLanguage = "ru-RU";
    response.Headers.ContentType = "text/plain; charset=utf-8";  // response.ContentType
    response.ContentType = "text/html; charset=utf-8";
    response.Headers.Append("secret-id", "256");    // добавление кастомного заголовка
    response.StatusCode = 404;
    await response.WriteAsync("Привет METANIT.COM", System.Text.Encoding.Default);
    await response.WriteAsync("<h2>Hello METANIT.COM</h2><h3>Welcome to ASP.NET Core</h3>");
    //response.SendFileAsync()
});

app.Run();

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

