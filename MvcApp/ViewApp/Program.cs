var builder = WebApplication.CreateBuilder(args);

// добавл€ем поддержку контроллеров с представлени€ми
builder.Services.AddControllersWithViews();
// внедр€ем сервис ITimeService
builder.Services.AddTransient<ITimeService, SimpleTimeService>();
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