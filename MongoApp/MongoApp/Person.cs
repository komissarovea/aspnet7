using MongoDB.Bson;

namespace MongoApp
{
    class Person
    {
        public ObjectId Id { get; set; }

        public string? Name { get; set; }

        public int Age { get; set; }

        public Company? Company { get; set; }

        public List<string>? Languages { get; set; } = new List<string>();
    }

    class Company
    {
        public string? Name { get; set; }
    }
}
