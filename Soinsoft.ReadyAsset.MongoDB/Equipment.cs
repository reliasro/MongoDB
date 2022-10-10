using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace Soinsoft.ReadyAsset.MongoDB
{
    internal class Equipment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public int Type { get; set; }
        public DateTime LastMaintenance { get; set; }
        public decimal CurrentValue { get; set; }
        public Company Owner { get; set; }
    }
}
