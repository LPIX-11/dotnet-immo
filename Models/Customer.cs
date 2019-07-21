using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Immovable.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string customerId { get; set; }

        [BsonElement("customerCivility")]
        public string customerCivility { get; set; }

        [BsonElement("customerName")]
        public string customerName { get; set; }

        [BsonElement("customerSurname")]
        public string customerSurname { get; set; }

        [BsonElement("customerPhone")]
        public string customerPhone { get; set; }

        [BsonElement("customerEmail")]
        public string customerEmail { get; set; }

        [BsonElement("customerNIC")]
        public string customerNIC { get; set; }

    }
}