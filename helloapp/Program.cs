using Microsoft.AspNetCore.Localization;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/",
    (HttpContext context) =>
    {
        return "Hello World!";
    });

int x = 2;
int y = 1;
app.Run(async (context) =>
{
    x = x * 2;  //  2 * 2 = 4
    y++;
    await context.Response.WriteAsync($"Result: 2^{y} = {x}");
});

app.Run(HandleRequst);

app.Run(async (context) => await context.Response.WriteAsync("Hello METANIT.COM"));

app.UseWelcomePage();

app.Run();

async Task HandleRequst(HttpContext context)
{
    await context.Response.WriteAsync("Hello METANIT.COM 2");
}


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

