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
                IMongoDatabase database = client.GetDatabase("test");
                var db = client.GetDatabase("test");
               // await db.CreateCollectionAsync("people");  // создаем коллекцию "people"

                var collections = await db.ListCollectionNamesAsync(); // await db.ListCollectionsAsync();
                foreach (var collection in collections.ToList())
                {
                    Console.WriteLine(collection);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine();
        }
    }
}