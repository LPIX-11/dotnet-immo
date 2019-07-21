using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class PaymentTypeService
    {
        private IMongoCollection<PaymentType> _paymentTypes;

        public PaymentTypeService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _paymentTypes = database.GetCollection<PaymentType>(settings.ImmovableCollectionName = "PaymentTypeCollection");
        }

        public List<PaymentType> Get() => _paymentTypes.Find(paymentType => true).ToList();

        public PaymentType Get(string id) => _paymentTypes.Find(paymentType => paymentType.paymentTypeId == id).FirstOrDefault();

        public PaymentType Create(PaymentType paymentType)
        {
            _paymentTypes.InsertOne(paymentType);
            return paymentType;
        }

        public void Update(string id, PaymentType paymentTypeIn) => _paymentTypes.ReplaceOneAsync(paymentType => paymentType.paymentTypeId == id, paymentTypeIn);

        public void Remove(string id) => _paymentTypes.DeleteOne(paymentType => paymentType.paymentTypeId == id);

    }
}

