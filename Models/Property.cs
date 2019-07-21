using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Property
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string propertyId { get; set; }

        [BsonElement("Number")]
        [JsonProperty("Number")]
        public string propertyNumber { get; set; }

        [BsonElement("Location")]
        [JsonProperty("Location")]
        public string propertyLocation { get; set; }

        [BsonElement("Price")]
        [JsonProperty("Price")]
        public int propertyPrice { get; set; }

        [BsonElement("Status")]
        [JsonProperty("Status")]
        public string propertyStatus { get; set; }

        [BsonRequired]
        [BsonElement("Lessor")]
        [JsonProperty("Lessor")]
        public virtual Lessor lessor { get; set; }

        [BsonElement("Area")]
        [JsonProperty("Area")]
        public string propertyArea { get; set; }

        [BsonElement("Rooms")]
        [JsonProperty("Rooms")]
        public int propertyRooms { get; set; }

        [BsonElement("hassGarden")]
        [JsonProperty("hassGarden")]
        public bool propertyHasGarden { get; set; }

        [BsonElement("Description")]
        [JsonProperty("Description")]
        public string propertyDescription { get; set; }

        [BsonElement("isLoging")]
        [JsonProperty("isLoging")]
        public bool propertyIsLodgin { get; set; }

        [BsonElement("hasElevator")]
        [JsonProperty("hasElevator")]
        public bool propertyHasElevator { get; set; }

        [BsonRequired]
        [BsonElement("Pics")]
        [JsonProperty("Pics")]
        public virtual IEnumerable<Picture> pic { get; set; }
    }
}