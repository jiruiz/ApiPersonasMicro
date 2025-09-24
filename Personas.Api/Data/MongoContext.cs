using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Personas.Api.Models;

namespace Personas.Api.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public MongoContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
            _collectionName = settings.Value.Collection;
        }

        public IMongoCollection<Persona> Personas
            => _database.GetCollection<Persona>(_collectionName);
    }
}
