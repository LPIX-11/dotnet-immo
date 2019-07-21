using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class YearMonthPayment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string yearMonthPaymentId { get; set; }

        [BsonRequired]
        [BsonElement("yearMonth")]
        [JsonProperty("yearMonth")]
        public virtual YearMonth yearMonth { get; set; }
    }
}