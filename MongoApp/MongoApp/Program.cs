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

                var projection = Builders<BsonDocument>.Projection.Include("Name").Include("Age").Exclude("_id");
                var users = await collection.Find(new BsonDocument()).Project(projection).ToListAsync();

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
}