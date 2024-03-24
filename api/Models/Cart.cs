
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cart
    {
    
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public required string CartNumber { get; set; }
        public required string CartName { get; set; }
        public int expireMonth { get; set; }
        public int expireYear { get; set; }
        public int Cvv { get; set; }
    }