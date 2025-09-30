using System;
using System.ComponentModel.DataAnnotations;

namespace Negocios.Api.Models
{
    /// <summary>
    /// Representa un negocio con información fiscal y de contacto.
    /// </summary>
    public class Negocio
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Rubro { get; set; } = string.Empty;

        [Required, Phone]
        public string Telefono { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Correo { get; set; } = string.Empty;

        [Required, StringLength(13)]
        public string Cuit { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string CondicionIVA { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string RazonSocial { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime FechaInicioActividades { get; set; }

        [Range(1, 1000)]
        public int AntiguedadEnRubro { get; set; }

        [Required, StringLength(120)]
        public string Calle { get; set; } = string.Empty;

        [Required, StringLength(60)]
        public string Localidad { get; set; } = string.Empty;

        [Required, StringLength(60)]
        public string Provincia { get; set; } = string.Empty;
    }
}