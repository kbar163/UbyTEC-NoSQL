using webapi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace webapi.Services
{
    //MongoDBService es un servicio creado para conectar a la base de datos
    //creada en MongoDB, haciendo uso de las configuraciones especificadas en
    //el proyecto. Se encarga de ejecutar el manejo de los datos.
    public class MongoDBService
    {
        private readonly IMongoCollection<Feedback> _feedbackCollection;

        public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _feedbackCollection = database.GetCollection<Feedback>(mongoDBSettings.Value.CollectionName);
        }

        //Create data function

        public async Task CreateFeedbackAsync(Feedback newFeedback)
        {
            await _feedbackCollection.InsertOneAsync(newFeedback);
            return;
        }

        
        public async Task<List<Feedback>> GetFeedbackAsync(string id)
        {
            FilterDefinition<Feedback> filter = Builders<Feedback>.Filter.Eq("id",id);
            return await _feedbackCollection.Find(filter).ToListAsync();
        }

    }
}