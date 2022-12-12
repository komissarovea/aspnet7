using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
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
                var collection = db.GetCollection<Employee>("employees");

                var companies = await collection.Aggregate()
                    .Group(emp => emp.Company!.Title,   // группировка по свойству Company.Title
                    g => new CompanyModel       // из группы создаем объект CompanyModel
                    {
                        CompanyName = g.Key,
                        Employees = g.Select(e => e.Name).ToList() // выбираем в список имена сотрудников
                    })
                    .ToListAsync();

                foreach (var company in companies)
                {
                    Console.WriteLine(company.CompanyName);
                    foreach (var employeeName in company.Employees)
                        Console.WriteLine(employeeName);
                    Console.WriteLine();
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

    record Person2(string? Name);

    class CompanyModel
    {
        public string CompanyName { get; set; } = "";
        public List<string> Employees { get; set; } = new();
    }
    record Employee(ObjectId Id, string Name, int Age, Company? Company);
    record Company(string Title);
}