using webapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace webapi.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Series> _seriesCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _seriesCollection = database.GetCollection<Series>(mongoDBSettings.Value.CollectionName);
        }

        //Create data function

        public async Task CreateSeriesAsync(Series newSeries)
        {
            await _seriesCollection.InsertOneAsync(newSeries);
            return;
        }

        public async Task<List<Series>> GetAllSeriesAsync()
        {
            return await _seriesCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<List<Series>> GetSeriesAsync(string id)
        {
            FilterDefinition<Series> filter = Builders<Series>.Filter.Eq("id",id);
            return await _seriesCollection.Find(filter).ToListAsync();
        }

        public async Task UpdateSeriesAsync(string id, string seriesName)
        {
            FilterDefinition<Series> filter = Builders<Series>.Filter.Eq("id",id);
            UpdateDefinition<Series> update = Builders<Series>.Update.Set<string>("seriesName",seriesName);
            await _seriesCollection.UpdateOneAsync(filter,update);
            return;
        }

        public async Task DeleteSeriesAsync(string id) 
        {
            FilterDefinition<Series> filter = Builders<Series>.Filter.Eq("id",id);
            await _seriesCollection.DeleteOneAsync(filter);
            return;
        }
    }
}