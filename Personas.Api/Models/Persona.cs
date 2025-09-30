using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Personas.Api.Models
{
    /// <summary>
    /// Representa una persona almacenada en la base de datos.
    /// </summary>
    public class Persona
    {
        /// <summary>
        /// Identificador único de la persona (MongoDB ObjectId).
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = "";

        /// <summary>
        /// Apellido de la persona.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Apellido { get; set; } = "";
    }
}
