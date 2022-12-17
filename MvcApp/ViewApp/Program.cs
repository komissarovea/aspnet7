using Microsoft.AspNetCore.Mvc;
using ViewApp.Util;

var builder = WebApplication.CreateBuilder(args);

// добавляем поддержку контроллеров с представлениями
builder.Services.AddControllersWithViews();
// внедряем сервис ITimeService
builder.Services.AddTransient<ITimeService, SimpleTimeService>();

// устанавливаем движок представлений
builder.Services.Configure<MvcViewOptions>(options => {
    options.ViewEngines.Clear();
    options.ViewEngines.Insert(0, new CustomViewEngine());
});

var app = builder.Build();

// устанавливаем сопоставление маршрутов с контроллерами
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

public interface ITimeService
{
    string Time { get; }
}
public class SimpleTimeService : ITimeService
{
    public string Time => DateTime.Now.ToShortTimeString();
}