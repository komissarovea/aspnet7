// var builder = WebApplication.CreateBuilder(args);
var app = WebApplication.Create(args); // builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
