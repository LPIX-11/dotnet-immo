using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Immovable.Models
{
    public class Contract
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string contractId { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        [BsonElement("contractDate")]
        [JsonProperty("contractDate")]
        public BsonDateTime contractDate { get; set; }

        [BsonElement("contractCaution")]
        [JsonProperty("contractCaution")]
        public float contractCaution { get; set; }

        [BsonRequired]
        [BsonElement("contractProperty")]
        [JsonProperty("contractProperty")]
        public virtual Property property { get; set; }

        [BsonRequired]
        [BsonElement("contractCustomer")]
        [JsonProperty("contractCustomer")]
        public virtual Customer customer { get; set; }

        [BsonElement("contractLoanPrice")]
        [JsonProperty("contractLoanPrice")]
        public float contractLoanPrice { get; set; }

    }
}
