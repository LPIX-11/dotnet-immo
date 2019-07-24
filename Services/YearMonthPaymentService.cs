using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class YearMonthPaymentService
    {
        private IMongoCollection<YearMonthPayment> _yearMonthPayments;

        public YearMonthPaymentService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _yearMonthPayments = database.GetCollection<YearMonthPayment>(settings.ImmovableCollectionName = "YearMonthPaymentCollection");
        }

        public List<YearMonthPayment> Get() => _yearMonthPayments.Find(_yearMonthPayment => true).ToList();

        public YearMonthPayment Get(string id) => _yearMonthPayments.Find(_yearMonthPayment => _yearMonthPayment.yearMonthPaymentId == id).FirstOrDefault();

        public YearMonthPayment Create(YearMonthPayment yearMonthPayment)
        {
            _yearMonthPayments.InsertOne(yearMonthPayment);
            return yearMonthPayment;
        }

        public void Update(string id, YearMonthPayment yearMonthPaymentIn)
        {
            _yearMonthPayments.ReplaceOneAsync(_yearMonthPayment => _yearMonthPayment.yearMonthPaymentId == id, yearMonthPaymentIn);
        }

        public void Remove(string id)
        {
            _yearMonthPayments.DeleteOne(_yearMonthPayment => _yearMonthPayment.yearMonthPaymentId == id);
        }
    }
}