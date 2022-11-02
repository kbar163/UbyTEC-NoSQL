using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace webapi.Models
{
    //Modelo de datos utilizado para representar una serie.
    //Decoradores de dependencias MongoDB que permiten
    //la creacion de un identificador unico para cada serie,
    //el cual se utiliza como indice en la base de datos.
    public class Series
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string seriesName { get; set; } = null!;
        public string director { get; set; } = null!;
        public List<string> cast { get; set; } = null!;
        public int releaseYear { get; set; }
    }
}
