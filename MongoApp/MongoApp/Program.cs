using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

                Person person = new Person { Name = "Tom", Age = 38 };
                person.Company = new Company { Name = "Microsoft" };

                BsonDocument doc = person.ToBsonDocument();
                Console.WriteLine(doc);

                //BsonDocument doc = new BsonDocument
                //{
                //    {"Name","Tom"},
                //    {"Age", 38},
                //    {"Company", new BsonDocument{ {"Name" , "Microsoft"}} },
                //    {"Languages", new BsonArray{"english", "german", "spanish"} }
                //};
                //Person person = BsonSerializer.Deserialize<Person>(doc);
                //Console.WriteLine(person.ToJson());


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