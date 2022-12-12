using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Text.Json;

namespace MongoApp
{
    internal class Program
    {
        static async Task Main() // string[] args
        {
            try
            {
                MongoClient client = new MongoClient("mongodb://localhost:27017");
                var db = client.GetDatabase("test");

                var collection = db.GetCollection<BsonDocument>("users");
                // определяем построитель фильтров
                var builder = Builders<BsonDocument>.Filter;

                // определяем фильтр - находим все документы, где Name = "Tom"
                var filter = builder.Eq("Name", "Tom");

                var users = await collection.Find(filter).ToListAsync();
                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
            catch (Exception ex)
            {
                Type t = ex.GetType();
                Console.WriteLine(ex);
            }

            Console.WriteLine();
        }
    }
}