using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // определяем MongoClient как синглтон
            builder.Services.AddSingleton(new MongoClient("mongodb://localhost:27017"));

            var app = builder.Build();

            app.MapGet("/", async (MongoClient client) =>     // получаем MongoClient через DI
            {
                var db = client.GetDatabase("test");    // обращаемся к базе данных
                var collection = db.GetCollection<BsonDocument>("users"); // получаем коллекцию users
                                                                          // для теста добавляем начальные данные, если коллекция пуста
                if (await collection.CountDocumentsAsync("{}") == 0)
                {
                    await collection.InsertManyAsync(new List<BsonDocument>
                    {
                        new BsonDocument{ { "Name", "Tom" },{"Age", 22}},
                        new BsonDocument{ { "Name", "Bob" },{"Age", 42}}
                    });
                }
                var users = await collection.Find("{}").ToListAsync();
                return users.ToJson();  // отправляем клиенту все документы из коллекции
            });
            app.Run();
        }
    }
}