WebApplicationOptions options = new WebApplicationOptions() { Args = args };
WebApplicationBuilder builder = WebApplication.CreateBuilder(options);
//builder.Configuration
//builder.Environment
//builder.Host
//builder.Logging
//builder.Services
//builder.WebHost

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
