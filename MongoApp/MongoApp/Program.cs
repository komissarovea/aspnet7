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
                using (var cursor = await client.ListDatabasesAsync())
                {
                    var databases = cursor.ToList();
                    foreach (var database in databases)
                    {
                        Console.WriteLine(database);
                    }
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