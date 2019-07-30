using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class ContractService
    {
        private IMongoCollection<Contract> _contracts;

        public ContractService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            settings.ImmovableCollectionName = "ContractCollection";
            _contracts = database.GetCollection<Contract>(settings.ImmovableCollectionName);
        }

        public List<Contract> Get() => _contracts.Find(contract => true).ToList();

        public Contract Get(string id) => _contracts.Find(contract => contract.contractId == id).FirstOrDefault();

        public Contract Create(Contract contract)
        {
            _contracts.InsertOne(contract);
            return contract;
        }

        public void Update(string id, Contract contractIn) => _contracts.ReplaceOneAsync(contract => contract.contractId == id, contractIn);

        public void Remove(string id) => _contracts.DeleteOne(contract => contract.contractId == id);

    }
}

