using Personas.Api.Models;

namespace Personas.Api.Repositories
{
    public interface IPersonaRepository
    {
        Task<List<Persona>> GetAllAsync();
        Task<Persona?> GetByIdAsync(string id);
        Task CreateAsync(Persona persona);
    }
}
