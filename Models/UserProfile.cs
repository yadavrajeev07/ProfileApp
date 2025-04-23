using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserProfileApp.Models
{
    public class UserProfile
    {
        [BsonId]
        public ObjectId Id { get; set; }

       public string? FirstName { get; set; }
public string? LastName { get; set; }
public string? Country { get; set; }
public string? State { get; set; }

    }
}
