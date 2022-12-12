using MongoDB.Bson;
using MongoDB.Driver;

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

                //BsonDocument doc = new BsonDocument();

                //BsonElement name = new BsonElement("name", "Tom");
                //BsonDocument doc = new BsonDocument(name);
                //Console.WriteLine(doc); // { "name" : "Tom" }

                //BsonDocument doc = new BsonDocument
                //{
                //    {"name","Tom"},
                //    {"age", 38},
                //    { "company", new BsonDocument{{"name" , "microsoft"}}},
                //    {"languages", new BsonArray{"english", "german", "spanish" } }
                //};
                //// получаем значение поля name
                //Console.WriteLine(doc["name"]);         // Tom
                //                                        // получаем значение поля languages
                //Console.WriteLine(doc["languages"]);    // [english, german, spanish]
                //// изменяем значение поля age
                //doc["age"] = 22;
                //Console.WriteLine(doc["age"]);      // 22

                BsonDocument doc = new BsonDocument { { "name", "Bob" } };
                BsonElement email = new BsonElement("email", "bob@localhost.com");
                // добавляем элемент email
                doc.Add(email);
                Console.WriteLine(doc);    // { "name" : "Bob", "email" : "bob@localhost.com" }
                // удаляем элемент name
                doc.Remove("name");
                Console.WriteLine(doc);  // { "email" : "bob@localhost.com" }

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