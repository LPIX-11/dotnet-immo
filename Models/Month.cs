using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Month
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string monthId { get; set; }

        [BsonElement("month")]
        [JsonProperty("month")]
        public string month { get; set; }
    }
}