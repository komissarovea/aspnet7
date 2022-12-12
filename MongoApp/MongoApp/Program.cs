using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Reflection.Metadata;
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
                var collection = db.GetCollection<BsonDocument>("employees");

                var employees = await collection.Aggregate()
                    .Group(new BsonDocument {
        { "_id", "$Company.Title" },               // группируем по имени компании
        { "count", new BsonDocument("$sum", 1) }, // получаем количество документов в группе
                    })
                    .ToListAsync();

                foreach (var employeeGroup in employees)
                    Console.WriteLine(employeeGroup);

            }
            catch (Exception ex)
            {
                Type t = ex.GetType();
                Console.WriteLine(ex);
            }

            Console.WriteLine();
        }
    }

    record Person2(string? Name);
}