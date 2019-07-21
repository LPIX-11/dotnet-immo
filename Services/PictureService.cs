using Immovable.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Immovable.Services
{
    public class PictureService
    {
        private IMongoCollection<Picture> _pictures;

        public PictureService(IImmovableStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pictures = database.GetCollection<Picture>(settings.ImmovableCollectionName = "PictureCollection");
        }

        public List<Picture> Get() => _pictures.Find(picture => true).ToList();

        public Picture Get(string id) => _pictures.Find(picture => picture.pictureId == id).FirstOrDefault();

        public Picture Create(Picture picture)
        {
            _pictures.InsertOne(picture);
            return picture;
        }

        public void Update(string id, Picture pictureIn) => _pictures.ReplaceOneAsync(picture => picture.pictureId == id, pictureIn);

        public void Remove(string id) => _pictures.DeleteOne(picture => picture.pictureId == id);

    }
}

