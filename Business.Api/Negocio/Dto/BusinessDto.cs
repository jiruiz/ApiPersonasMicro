using System;

namespace Business.Api.Negocio.Dto
{
    /// <summary>
    /// Data Transfer Object for Business entity.
    /// </summary>
    public class BusinessDto
    {
        public int Id { get; set; }  // Id

        public string Name { get; set; } = string.Empty;  // Nombre

        public string Industry { get; set; } = string.Empty;  // Rubro

        public string PhoneNumber { get; set; } = string.Empty;  // Teléfono

        public string Email { get; set; } = string.Empty;  // Correo

        public string TaxId { get; set; } = string.Empty;  // CUIT

        public string VATStatus { get; set; } = string.Empty;  // Condición IVA

        public string LegalName { get; set; } = string.Empty;  // Razón Social

        public DateTime StartOfActivities { get; set; }  // Fecha de inicio de actividades

        public int YearsInIndustry { get; set; }  // Antigüedad en el rubro

        public string Street { get; set; } = string.Empty;  // Calle

        public string City { get; set; } = string.Empty;  // Localidad

        public string State { get; set; } = string.Empty;  // Provincia
    }
}
