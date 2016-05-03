using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using PG.Common;
using PG.Common.Repository;

namespace PG.DataAccessLayer.Repository
{
    public class DataAccess : IDataCrud
    {
        static string connectionString = "mongodb://localhost";
        static MongoClient client = new MongoClient(connectionString);
        static IMongoDatabase database = client.GetDatabase("users");
        static IMongoCollection<User> collection = database.GetCollection<User>("users");
        // Guid


        public async void CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();

            await collection.InsertOneAsync(user);
        }

        public  User GetUser(string id)
        {
            var users =  collection.Find(FilterDefinition<User>.Empty).ToList();
            foreach (var user in users)
            {
                if (user.Id == id)
                {
                    User use = new User(user.FirstName, user.LastName);
                    use.Id = id;
                    return use;
                }
            }
            return null;
        }

        public async void UpdateUser(string id, User user)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            var update = Builders<User>.Update.Set(u => u.FirstName, user.FirstName);
            await collection.UpdateOneAsync(filter, update);
            update = Builders<User>.Update.Set(u => u.LastName, user.LastName);
            await collection.UpdateOneAsync(filter, update);
        }

        public async void RemoveUser(string id)
        {
            await collection.DeleteOneAsync(u => u.Id == id);
        }
    }
}
