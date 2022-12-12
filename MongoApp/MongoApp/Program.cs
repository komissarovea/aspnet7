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

                BsonElement el = new BsonElement("name", new BsonString("Tom"));
                Console.WriteLine(el); // name = Tom
                Console.WriteLine(el.Name); // name
                Console.WriteLine(el.Value); // Tom


                BsonElement ageElement = new BsonElement("age", 38);
                Console.WriteLine(ageElement); // age = 38
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