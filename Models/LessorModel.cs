using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Lessor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string lessorId { get; set; }

        [BsonElement("lessorCivility")]
        [JsonProperty("lessorCivility")]
        public string lessorCivility { get; set; }

        [BsonElement("lessorName")]
        [JsonProperty("lessorName")]
        public string lessorName { get; set; }

        [BsonElement("lessorSurname")]
        [JsonProperty("lessorSurname")]
        public string lessorSurname { get; set; }

        [BsonElement("lessorEmail")]
        [JsonProperty("lessorEmail")]
        public string lessorEmail { get; set; }

        [BsonElement("lessorphone")]
        [JsonProperty("lessorphone")]
        public string lessorPhone { get; set; }

        [BsonElement("lessorNIC")]
        [JsonProperty("lessorNIC")]
        public string lessorNIC { get; set; }

        [BsonElement("lessorAdress")]
        [JsonProperty("lessorAdress")]
        public string lessorAdress { get; set; }

        [BsonElement("lessorType")]
        [JsonProperty("lessorType")]
        public string lessorType { get; set; }

    }
}