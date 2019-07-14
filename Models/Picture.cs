using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Immovable.Models
{
    public class Picture
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string pictureId { get; set; }

        [BsonElement("Path")]
        public string picturePath { get; set; }
    }
}