using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Api.Datos.Models
{
    /// <summary>
    /// Represents a business with fiscal and contact information.
    /// </summary>
    public class Business
    {
        public int Id { get; set; } 

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Industry { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(13)]
        public string TaxId { get; set; } = string.Empty;

        [Required, StringLength(30)]
        public string VATStatus { get; set; } = string.Empty;

        [Required, StringLength(150)]
        public string LegalName { get; set; } = string.Empty;

        [Required, DataType(DataType.Date)]
        public DateTime StartOfActivities { get; set; }

        [Range(1, 1000)]
        public int YearsInIndustry { get; set; }

        [Required, StringLength(120)]
        public string Street { get; set; } = string.Empty;

        [Required, StringLength(60)]
        public string City { get; set; } = string.Empty;

        [Required, StringLength(60)]
        public string State { get; set; } = string.Empty;
    }
}
