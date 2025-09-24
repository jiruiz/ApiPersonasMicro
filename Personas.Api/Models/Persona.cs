using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Personas.Api.Models
{
    public class Persona
    {
        [BsonId] // Mongo usa un ObjectId como clave
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
    }
}
