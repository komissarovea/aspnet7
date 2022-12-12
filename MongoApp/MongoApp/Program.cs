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
                var collection = db.GetCollection<BsonDocument>("users");

                await collection.BulkWriteAsync(new WriteModel<BsonDocument>[]
                 {
                    new InsertOneModel<BsonDocument>(new BsonDocument{{"Name", "Tom"}, {"Age", 38 } })
                 });

                var people = await collection.Find("{}").ToListAsync();
                foreach (var person in people) Console.WriteLine(person);
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

    class CompanyModel
    {
        public string CompanyName { get; set; } = "";
        public List<string> Employees { get; set; } = new();
    }
    record Employee(ObjectId Id, string Name, int Age, Company? Company);
    record Company(string Title);
}