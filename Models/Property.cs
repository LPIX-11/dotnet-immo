using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Immovable.Models
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string propertyId { get; set; }

        [BsonElement("Number")]
        public string propertyNumber { get; set; }

        [BsonElement("Location")]
        public string propertyLocation { get; set; }

        [BsonElement("Price")]
        public int propertyPrice { get; set; }

        [BsonElement("Status")]
        public string propertyStatus { get; set; }

        [BsonRequired]
        [BsonElement("Lessor")]
        public virtual Lessor lessor { get; set; }

        [BsonElement("Area")]
        public string propertyArea { get; set; }

        [BsonElement("Rooms")]
        public int propertyRooms { get; set; }

        [BsonElement("hassGarden")]
        public bool propertyHasGarden { get; set; }

        [BsonElement("Description")]
        public string propertyDescription { get; set; }

        [BsonElement("isLoging")]
        public bool propertyIsLodgin { get; set; }

        [BsonElement("hasElevator")]
        public bool propertyHasElevator { get; set; }

        [BsonRequired]
        [BsonElement("Pics")]
        public virtual IEnumerable<Picture> pic { get; set; }
    }
}