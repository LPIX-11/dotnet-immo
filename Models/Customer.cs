using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string customerId { get; set; }

        [BsonElement("customerCivility")]
        [JsonProperty("customerCivility")]
        public string customerCivility { get; set; }

        [BsonElement("customerName")]
        [JsonProperty("customerName")]
        public string customerName { get; set; }

        [BsonElement("customerSurname")]
        [JsonProperty("customerSurname")]
        public string customerSurname { get; set; }

        [BsonElement("customerPhone")]
        [JsonProperty("customerPhone")]
        public string customerPhone { get; set; }

        [BsonElement("customerEmail")]
        [JsonProperty("customerEmail")]
        public string customerEmail { get; set; }

        [BsonElement("customerNIC")]
        [JsonProperty("customerNIC")]
        public string customerNIC { get; set; }

    }
}