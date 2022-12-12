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
                //using (var cursor = await client.ListDatabasesAsync())
                //using (var cursor = await client.ListDatabaseNamesAsync())
                //{
                //    var databases = cursor.ToList();
                //    foreach (var database in databases)
                //    {
                //        Console.WriteLine(database);
                //    }
                //}

                IMongoDatabase database = client.GetDatabase("test");
                var grades = database.GetCollection<object>("grades");
                Console.WriteLine(grades);

                await client.DropDatabaseAsync("test2");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine();
        }
    }
}