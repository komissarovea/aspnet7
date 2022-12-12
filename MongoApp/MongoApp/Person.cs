using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoApp
{
    class Person
    {
        //[BsonId]
        //public ObjectId Id { get; set; }

        [BsonId]
        public int PersonId { get; set; }

        //[BsonElement("Login")]
        public string? Name { get; set; }

        [BsonIgnoreIfDefault]
        public string Email { get; set; } = "";

        //[BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.String)]
        public int Age { get; set; }

        [BsonIgnoreIfNull]
        public Company? Company { get; set; }

        public List<string>? Languages { get; set; } = new List<string>();
    }

    class Company
    {
        public string? Name { get; set; } = "";
    }
}
