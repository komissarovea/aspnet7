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

                // получаем первый документ
                var user = await collection.Find("{}").FirstAsync();
                Console.WriteLine(user);

                // получаем первый документ, у которого Age = 33
                var user33 = await collection.Find(new BsonDocument("Age", 33)).FirstAsync();
                Console.WriteLine(user33);
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