using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class PaymentService
    {
        private IMongoCollection<Payment> _payments;

        public PaymentService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            settings.ImmovableCollectionName = "PaymentCollection";
            _payments = database.GetCollection<Payment>(settings.ImmovableCollectionName);
        }

        public List<Payment> Get() => _payments.Find(payment => true).ToList();

        public Payment Get(string id) => _payments.Find(payment => payment.paymentId == id).FirstOrDefault();

        public Payment Create(Payment payment)
        {
            _payments.InsertOne(payment);
            return payment;
        }

        public void Update(string id, Payment paymentIn) => _payments.ReplaceOneAsync(payment => payment.paymentId == id, paymentIn);

        public void Remove(string id) => _payments.DeleteOne(payment => payment.paymentId == id);

    }
}

