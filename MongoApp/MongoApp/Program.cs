using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;

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

                // получаем из бд коллекцию users
                var collection = db.GetCollection<Person>("users");
                // получаем список всех данных
                //List<BsonDocument> users = await collection.Find(new BsonDocument()).ToListAsync();

                // получаем курсор
                using var cursor = await collection.FindAsync(new BsonDocument());
                // из курсора получаем список данных
                List<Person> users = cursor.ToList();

                foreach (var user in users)
                {
                    // Console.WriteLine(user);
                    Console.WriteLine($"{user.Name} - {user.Age}");
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