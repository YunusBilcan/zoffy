
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cart
    {
    
        [BsonId]
        public ObjectId Id { get; set; }
        public string UserId { get; set; }
        public string CartNumber { get; set; }
        public string CartName { get; set; }
        public int expireMonth { get; set; }
        public int expireYear { get; set; }
        public int Cvv { get; set; }
    }