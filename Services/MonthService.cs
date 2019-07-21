using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class MonthService
    {
        private IMongoCollection<Month> _months;

        public MonthService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _months = database.GetCollection<Month>(settings.ImmovableCollectionName = "MonthCollection");
        }

        public List<Month> Get() => _months.Find(month => true).ToList();

        public Month Get(string id) => _months.Find(month => month.monthId == id).FirstOrDefault();

        public Month Create(Month month)
        {
            _months.InsertOne(month);
            return month;
        }

        public void Update(string id, Month monthIn) => _months.ReplaceOneAsync(month => month.monthId == id, monthIn);

        public void Remove(string id) => _months.DeleteOne(month => month.monthId == id);

    }
}

