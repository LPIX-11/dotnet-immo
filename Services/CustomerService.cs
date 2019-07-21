using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class CustomerService
    {
        private IMongoCollection<Customer> _customers;

        public CustomerService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customers = database.GetCollection<Customer>(settings.ImmovableCollectionName = "CustomerCollection");
        }

        public List<Customer> Get() => _customers.Find(customer => true).ToList();

        public Customer Get(string id) => _customers.Find(customer => customer.customerId == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customers.InsertOne(customer);
            return customer;
        }

        public void Update(string id, Customer customerIn) => _customers.ReplaceOneAsync(customer => customer.customerId == id, customerIn);

        public void Remove(string id) => _customers.DeleteOne(customer => customer.customerId == id);

    }
}

