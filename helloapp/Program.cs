WebApplicationOptions options = new WebApplicationOptions() { Args = args };
WebApplicationBuilder builder = WebApplication.CreateBuilder(options);
//builder.Configuration
//builder.Environment
//builder.Host
//builder.Logging
//builder.Services
//builder.WebHost

WebApplication app = builder.Build();
IHost host = app;
IApplicationBuilder applicationBuilder = app;
IEndpointRouteBuilder endpointRouteBuilder = app;
//app.Configuration
//app.Environment
//app.Lifetime
//app.Logger
//app.Services
//app.Urls

app.MapGet("/", () => "Hello World!");

//app.Run();
//app.RunAsync();
//app.Start();
//app.StartAsync();
//app.StopAsync();

await app.StartAsync();
await Task.Delay(10000);
await app.StopAsync();  // через 10 секунд завершаем выполнение приложения
