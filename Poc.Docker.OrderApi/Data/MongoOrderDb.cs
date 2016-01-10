using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Poc.Docker.OrderApi.Model;

namespace Poc.Docker.OrderApi.Data
{
    public class MongoOrderDb
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<Order> _collection;
        private const string ConnectionString = "mongodb://192.168.99.100:27017";

        static MongoOrderDb()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("test");
        }

        public MongoOrderDb()
        {
            _collection = _database.GetCollection<Order>("orders");
        }

        public async Task<string> InsertOrder(Order order)
        {
            Console.WriteLine("DEBUG : Enter in ** InsertOrder ** method")
            string id = Guid.NewGuid().ToString();
            order.Id = id;
            Console.WriteLine("DEBUG : Try to insert order")
            await _collection.InsertOneAsync(order);
            return id;
        }

        public async Task<Order> GetOrder(string id)
        {
            var filter = Builders<Order>.Filter.Eq(x => x.Id, id);
            List<Order> orders = await _collection.Find(filter).ToListAsync();
            return orders.FirstOrDefault();
        }
    }
}
