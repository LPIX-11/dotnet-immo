using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Picture
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string pictureId { get; set; }

        [BsonElement("Path")]
        [JsonProperty("Path")]
        public string picturePath { get; set; }
    }
}