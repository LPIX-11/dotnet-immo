using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Immovable.Models
{
    public class Lessor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string lessorId { get; set; }

        [BsonElement("lessorCivility")]
        public string lessorCivility { get; set; }

        [BsonElement("lessorName")]
        public string lessorName { get; set; }

        [BsonElement("lessorSurname")]
        public string lessorSurname { get; set; }

        [BsonElement("lessorEmail")]
        public string lessorEmail { get; set; }

        [BsonElement("lessorphone")]
        public string lessorPhone { get; set; }

        [BsonElement("lessorNIC")]
        public string lessorNIC { get; set; }

        [BsonElement("lessorAdress")]
        public string lessorAdress { get; set; }

        [BsonElement("lessorType")]
        public string lessorType { get; set; }

    }
}