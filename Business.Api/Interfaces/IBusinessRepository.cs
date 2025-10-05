using Business.Api.Dto;
using Business.Api.Models;

namespace Business.Api.Interfaces
{
    public interface IBusinessRepository
    {
        // ✅ Obtener todos los negocios
        ICollection<BusinessDto> GetBusinesses();

        // ✅ Obtener un negocio por ID
        Models.Business GetBusinessById(int id);

        // ✅ Obtener negocios por rubro (Industry)
        ICollection<BusinessDto> GetBusinessesByIndustry(string industry);

        // ✅ Agregar un nuevo negocio
        bool AddBusiness(BusinessDto business);

        // ✅ Guardar cambios en la base de datos
        bool Save();
    }
}
