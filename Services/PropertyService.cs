using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class PropertyService
    {
        private IMongoCollection<Property> _properties;

        public PropertyService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _properties = database.GetCollection<Property>(settings.ImmovableCollectionName = "PropertyCollection");
        }

        public List<Property> Get() => _properties.Find(property => true).ToList();

        public Property Get(string id) => _properties.Find(property => property.propertyId == id).FirstOrDefault();

        public Property Create(Property property)
        {
            _properties.InsertOne(property);
            return property;
        }

        public void Update(string id, Property propertyIn)
        {
            _properties.ReplaceOneAsync(property => property.propertyId == id, propertyIn);
        }

        public void Remove(string id)
        {
            _properties.DeleteOne(property => property.propertyId == id);
        }
    }
}