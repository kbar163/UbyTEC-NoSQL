namespace webapi.Models
{
    //Clase utilizada para setear las configuraciones de la instancia de MongoDB utilizada como base de datos,
    //esta clase se instancia como un singleton en Program.cs haciendo uso de datos de conexion configurados
    //en appsettings.json.
    
    public class MongoDBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}