using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class PropertyService
    {
        private readonly IMongoCollection<Property> _properties;

        public PropertyService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _properties = database.GetCollection<Property>(settings.ImmovableCollectionName);
        }

        public List<Property> Get() => _properties.Find(property => true).ToList();

        public Property Get(string id) => _properties.Find<Property>(property => property.propertyId == id).FirstOrDefault();

        public void Remove(string id) => _properties.DeleteOne(property => property.propertyId == id);
    }
}