using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class LessorService
    {
        private IMongoCollection<Lessor> _lessors;

        public LessorService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _lessors = database.GetCollection<Lessor>(settings.ImmovableCollectionName = "LessorCollection");
        }

        public List<Lessor> Get() => _lessors.Find(lessor => true).ToList();

        public Lessor Get(string id) => _lessors.Find(lessor => lessor.lessorId == id).FirstOrDefault();

        public Lessor Create(Lessor lessor)
        {
            _lessors.InsertOne(lessor);
            return lessor;
        }

        public void Update(string id, Lessor lessorIn)
        {
            _lessors.ReplaceOneAsync(lessor => lessor.lessorId == id, lessorIn);
        }

        public void Remove(string id)
        {
            _lessors.DeleteOne(lessor => lessor.lessorId == id);
        }
    }
}