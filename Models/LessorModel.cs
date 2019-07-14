using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Immovable.Models
{
    public class Lessor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string lessorId { get; set; }

        [BsonElement("Civility")]
        public string lessorCivility { get; set; }

        [BsonElement("Name")]
        public string lessorName { get; set; }

        [BsonElement("Surname")]
        public string lessorSurname { get; set; }

        [BsonElement("Email")]
        public string lessorEmail { get; set; }

        [BsonElement("phone")]
        public string lessorPhone { get; set; }

        [BsonElement("NIC")]
        public string lessorNIC { get; set; }

        [BsonElement("Adress")]
        public string lessorAdress { get; set; }

        [BsonElement("Type")]
        public string lessorType { get; set; }

    }
}