using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Demo.Data.Mongo.Models
{
    public class User
    {
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("firstName")]
        [BsonRepresentation(BsonType.String)]
        [BsonIgnoreIfNull]
        public string FirstName { get; set; }

        [BsonElement("latstName")]
        [BsonRepresentation(BsonType.String)]
        [BsonIgnoreIfNull]
        public string LastName { get; set; }

        [BsonElement("email")]
        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("password")]
        [BsonRepresentation(BsonType.String)]
        [BsonRequired]
        public string Password { get; set; }

        [BsonElement("created")]
        [BsonRepresentation(BsonType.Boolean)]
        [BsonRequired]
        public DateTime Created { get; set; }
    }
}