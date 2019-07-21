using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Payment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string paymentId { get; set; }

        [BsonElement("paymentNumber")]
        [JsonProperty("paymentNumber")]
        public string paymentNumber { get; set; }

        [BsonElement("paymentDate")]
        [JsonProperty("paymentDate")]
        [BsonRepresentation(BsonType.DateTime)]
        public BsonDateTime paymentDate { get; set; }

        [BsonRequired]
        [BsonElement("paymentContract")]
        [JsonProperty("paymentContract")]
        public virtual Contract contract { get; set; }

        [BsonRequired]
        [BsonElement("paymentType")]
        [JsonProperty("paymentType")]
        public virtual PaymentType paymentType { get; set; }
    }

}
