using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class PaymentType
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string paymentTypeId { get; set; }

        [BsonElement("paymentType")]
        [JsonProperty("paymentType")]
        public string paymentType { get; set; }
    }
}