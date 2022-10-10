using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Soinsoft.ReadyAsset.MongoDB
{
    internal class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string CompleteName { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}
