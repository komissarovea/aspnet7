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

                var collection = db.GetCollection<Person>("users");

                var builder = Builders<Person>.Filter;
                var filter = builder.Where(p => p.Age < 30);

                var users = await collection.Find(filter).ToListAsync();
                foreach (var user in users)
                {
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