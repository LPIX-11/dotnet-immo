using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Year
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string yearId { get; set; }

        [BsonElement("year")]
        [JsonProperty("year")]
        public string year { get; set; }
    }
}