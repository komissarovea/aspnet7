using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // ���������� MongoClient ��� ��������
            builder.Services.AddSingleton(new MongoClient("mongodb://localhost:27017"));

            var app = builder.Build();

            app.MapGet("/", async (MongoClient client) =>     // �������� MongoClient ����� DI
            {
                var db = client.GetDatabase("test");    // ���������� � ���� ������
                var collection = db.GetCollection<BsonDocument>("users"); // �������� ��������� users
                                                                          // ��� ����� ��������� ��������� ������, ���� ��������� �����
                if (await collection.CountDocumentsAsync("{}") == 0)
                {
                    await collection.InsertManyAsync(new List<BsonDocument>
                    {
                        new BsonDocument{ { "Name", "Tom" },{"Age", 22}},
                        new BsonDocument{ { "Name", "Bob" },{"Age", 42}}
                    });
                }
                var users = await collection.Find("{}").ToListAsync();
                return users.ToJson();  // ���������� ������� ��� ��������� �� ���������
            });
            app.Run();
        }
    }
}