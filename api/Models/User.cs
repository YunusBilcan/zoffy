
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
    {
    
        [BsonId]
        public ObjectId Id { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? TC { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Salary { get; set; }
        public string? Job { get; set; }
        public string? UserPicture { get; set; }
    }