using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class YearMonthService
    {
        private IMongoCollection<YearMonth> _yearMonths;

        public YearMonthService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            settings.ImmovableCollectionName = "YearMonthCollection";
            _yearMonths = database.GetCollection<YearMonth>(settings.ImmovableCollectionName);
        }

        public List<YearMonth> Get() => _yearMonths.Find(yearMonth => true).ToList();

        public YearMonth Get(string id) => _yearMonths.Find(yearMonth => yearMonth.yearMonthId == id).FirstOrDefault();

        public YearMonth Create(YearMonth yearMonth)
        {
            _yearMonths.InsertOne(yearMonth);
            return yearMonth;
        }

        public void Update(string id, YearMonth yearMonthIn) => _yearMonths.ReplaceOneAsync(yearMonth => yearMonth.yearMonthId == id, yearMonthIn);

        public void Remove(string id) => _yearMonths.DeleteOne(yearMonth => yearMonth.yearMonthId == id);

    }
}

