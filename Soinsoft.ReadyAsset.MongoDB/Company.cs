using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Soinsoft.ReadyAsset.MongoDB
{
    internal class Company
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string RegisterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Country { get; set; }
    }
}
