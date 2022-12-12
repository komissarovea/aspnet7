using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
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
                IGridFSBucket gridFS = new GridFSBucket(db);

                // создаем поток из файла
                using Stream fs = File.OpenRead("D:\\cats.jpg");
                // сохраняем в бд
                ObjectId id = await gridFS.UploadFromStreamAsync("cats.jpg", fs);
                Console.WriteLine($"id файла: {id}");
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