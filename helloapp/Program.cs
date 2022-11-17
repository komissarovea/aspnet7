using Microsoft.AspNetCore.Localization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/",
    (HttpContext context) =>
    {
        var acceptLanguages = context.Request.GetTypedHeaders().AcceptLanguage.OrderByDescending(x => x.Quality ?? 1);
        var requestCulture = context.Features.Get<IRequestCultureFeature>();
        Console.WriteLine(context.Connection);
        Console.WriteLine(context.Features);
        Console.WriteLine(context.Items);
        Console.WriteLine(context.Request);
        Console.WriteLine(context.RequestAborted);
        Console.WriteLine(context.RequestServices);
        Console.WriteLine(context.Response);
        //Console.WriteLine(context.Session);
        Console.WriteLine(context.TraceIdentifier);
        Console.WriteLine(context.User);
        Console.WriteLine(context.WebSockets);
        return "Hello World!";
    });

app.Run();

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

