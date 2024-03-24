
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Cart
    {
    
        [BsonId]
        public ObjectId Id { get; set; }
<<<<<<< HEAD
        public string UserId { get; set; }
        public string CartNumber { get; set; }
        public string CartName { get; set; }
=======
        public ObjectId UserId { get; set; }
        public required string CartNumber { get; set; }
        public required string CartName { get; set; }
>>>>>>> ef125a3cde044403fae8ef5fc66a3af2e4cf0343
        public int expireMonth { get; set; }
        public int expireYear { get; set; }
        public int Cvv { get; set; }
    }