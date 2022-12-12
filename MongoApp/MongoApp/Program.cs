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
                var filter = Builders<GridFSFileInfo>.Filter.Eq(info => info.Filename, "cats.jpg");
                // находим все файлы по имени "cats.jpg"
                var fileInfos = await gridFS.FindAsync(filter);
                // получаем первый файл
                var fileInfo = fileInfos.FirstOrDefault();

                // если файл найден, удаляем его
                if (fileInfo != null)
                    await gridFS.DeleteAsync(fileInfo.Id);
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