using ApiProject.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ApiProject.Repositories
{
    /// <summary>
    /// Extrenal memory option, relying ontop docker.
    /// </summary>
    public class ExternalMongoRepo : ILocalAndExternalRepo
    {
        private const string RepositoryName = "MongoDbApiRepo";
        private const string CollectionName = "MongoDbApiCollection";
        private readonly IMongoCollection<Item> _repository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="mongoClient"></param>
        public ExternalMongoRepo(IMongoClient mongoClient) 
        {
            IMongoDatabase databse = mongoClient.GetDatabase(RepositoryName);
            _repository = databse.GetCollection<Item>(CollectionName);
        }

        public void CreateNewItem(Item item)
        {
            _repository.InsertOne(item);
        }

        public void DeleteItem(Guid id)
        {
            FilterDefinition<Item> filters = Builders<Item>.Filter.Eq("Id", id);
            _repository.DeleteOne(filters);
        }

        public Item GetItem(Guid id)
        {
            var temp = GetItems();
            foreach (var item in temp) 
            {
                if (item.Id == id) 
                {
                    return item;
                }
            }
            return null;
        }

        public IEnumerable<Item> GetItems()
        {
            return _repository.Find(new BsonDocument()).ToList();
        }

        public void UpdateItem(Item item)
        {
            FilterDefinition<Item> filter = Builders<Item>.Filter.Eq("Id", item.Id);
            UpdateDefinition<Item> updateName = Builders<Item>.Update.AddToSet<string>("Name", item.Name);
            UpdateDefinition<Item> updateDescription = Builders<Item>.Update.AddToSet<string>("Description", item.Description);

            _repository.UpdateOne(filter, updateName);
            _repository.UpdateOne(filter, updateDescription);

        }
    }
}
