using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webapi.Models
{
    //Modelo de datos utilizado para guardar un comentario de feedback en la base de datos NoSQL
    public class Feedback
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string FeedbackComment { get; set; } = null!;
        
    }
}