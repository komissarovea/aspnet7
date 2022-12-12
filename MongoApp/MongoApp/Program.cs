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
                //await db.RenameCollectionAsync("people", "users"); // из people в users
                await db.DropCollectionAsync("users");  // удаляем коллекцию "users"

                var collections = await db.ListCollectionNamesAsync(); // await db.ListCollectionsAsync();
                foreach (var collection in collections.ToList())
                {
                    Console.WriteLine(collection);
                }
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