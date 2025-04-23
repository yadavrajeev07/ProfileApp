using MongoDB.Driver;
using UserProfileApp.Models;

namespace UserProfileApp.Services
{
    public class UserProfileService
    {
        private readonly IMongoCollection<UserProfile> _profiles;

        public UserProfileService(IConfiguration config)
        {
            var settings = config.GetSection("MongoDBSettings").Get<MongoDBSettings>();
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _profiles = database.GetCollection<UserProfile>(settings.CollectionName);
        }

        public List<UserProfile> GetAll() => _profiles.Find(p => true).ToList();

        public void Create(UserProfile profile) => _profiles.InsertOne(profile);

        public void Update(string id, UserProfile updatedProfile) =>
            _profiles.ReplaceOne(p => p.Id == MongoDB.Bson.ObjectId.Parse(id), updatedProfile);
    }
}
