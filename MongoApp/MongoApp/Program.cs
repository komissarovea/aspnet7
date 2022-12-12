﻿using MongoDB.Bson;
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

                var conventionPack = new ConventionPack
                {
                    new CamelCaseElementNameConvention()
                };
                ConventionRegistry.Register("camelCase", conventionPack, t => true);

                BsonClassMap.RegisterClassMap<Person>(cm =>
                {
                    cm.AutoMap();
                    cm.MapMember(p => p.Name).SetElementName("username");
                });
                Person tom = new Person { Name = "Tom", Age = 38 };
                Console.WriteLine(tom.ToBsonDocument()); // { "username" : "Tom", "Age" : 38 }

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