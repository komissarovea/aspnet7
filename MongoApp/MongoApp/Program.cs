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

                // сначала сортируем по Name во возврастанию, а затем по Age по убыванию
                var sortDefinition = Builders<Person>.Sort.Ascending(p => p.Name).Descending(p => p.Age);
                var users = await collection.Find("{}").Sort(sortDefinition).ToListAsync();

                foreach (var user in users) Console.WriteLine($"{user.Name} - {user.Age}");
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