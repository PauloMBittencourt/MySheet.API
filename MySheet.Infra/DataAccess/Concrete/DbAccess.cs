using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MySheet.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySheet.Infra.DataAccess.Concrete
{
    public class DbAccess
    {
        private readonly IOptions<MongoDBSettings> mongoDBSettings;

        public DbAccess(IOptions<MongoDBSettings> mongoDBSettings)
        {
            this.mongoDBSettings = mongoDBSettings;
        }

        public IMongoCollection<T> ConnectToMongo<T>(string collection)
        {
            var settings = MongoClientSettings.FromConnectionString(mongoDBSettings.Value.ConnectionURI);

            settings.ServerApi = new ServerApi(ServerApiVersion.V1);

            var client = new MongoClient(settings);
            var db = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            return db.GetCollection<T>(collection);
        }

        public async Task<List<T>> GetAll<T>(string collection)
        {
            var coll = ConnectToMongo<T>(collection);
            var results = await coll.FindAsync(_ => true);

            return results.ToList();
        }
    }
}
