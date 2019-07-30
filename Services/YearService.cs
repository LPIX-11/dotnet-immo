using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class YearService
    {
        private IMongoCollection<Year> _years;

        public YearService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            settings.ImmovableCollectionName = "YearCollection";
            _years = database.GetCollection<Year>(settings.ImmovableCollectionName);
        }

        public List<Year> Get() => _years.Find(year => true).ToList();

        public Year Get(string id) => _years.Find(year => year.yearId == id).FirstOrDefault();

        public Year Create(Year year)
        {
            _years.InsertOne(year);
            return year;
        }

        public void Update(string id, Year yearIn) => _years.ReplaceOneAsync(year => year.yearId == id, yearIn);

        public void Remove(string id) => _years.DeleteOne(year => year.yearId == id);

    }
}

