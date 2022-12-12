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
                //var users = db.GetCollection<BsonDocument>("users");
                //// документ для добавления
                //BsonDocument tom = new BsonDocument
                //{
                //    {"Name", "Tom"},
                //    {"Age", 38}
                //};
                //// добавляем в коллекцию users документ
                //await users.InsertOneAsync(tom);

                //// документы для добавления
                //BsonDocument bob = new BsonDocument { { "Name", "Bob" }, { "Age", 42 } };
                //BsonDocument sam = new BsonDocument { { "Name", "Sam" }, { "Age", 25 } };

                //// добавляем в коллекцию users список документов
                //await users.InsertManyAsync(new List<BsonDocument> { bob, sam });

                // получаем из бд коллекцию users 
                // коллекция типизируется типом Person
                var users = db.GetCollection<Person>("users");
                // объект для добавления
                Person alice = new Person { Name = "Alice", Age = 33 };

                // добавляем в коллекцию users
                await users.InsertOneAsync(alice);

                Console.WriteLine(alice.Id);  // получаем сгенерированный Id
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