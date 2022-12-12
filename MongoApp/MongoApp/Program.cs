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

                var filter = Builders<BsonDocument>.Filter.Eq("Name", "Tom");
                var update = Builders<BsonDocument>.Update.Set("Age", 33).CurrentDate("LastModified");
                var result = await collection.UpdateManyAsync(filter, update);

                Console.WriteLine($"Matched: {result.MatchedCount}; Modified: {result.ModifiedCount}");

                var users = await collection.Find("{}").ToListAsync();
                foreach (var user in users) Console.WriteLine(user);

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