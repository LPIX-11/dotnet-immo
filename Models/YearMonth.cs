using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class YearMonth
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string yearMonthId { get; set; }

        [BsonRequired]
        [BsonElement("year")]
        [JsonProperty("year")]
        public virtual Year year { get; set; }

        [BsonRequired]
        [BsonElement("month")]
        [JsonProperty("month")]
        public virtual Month month { get; set; }
    }
}