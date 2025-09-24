using MongoDB.Driver;
using Personas.Api.Data;
using Personas.Api.Models;

namespace Personas.Api.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly MongoContext _context;

        public PersonaRepository(MongoContext context)
        {
            _context = context;
        }

        public async Task<List<Persona>> GetAllAsync() =>
            await _context.Personas.Find(_ => true).ToListAsync();

        public async Task<Persona?> GetByIdAsync(string id) =>
            await _context.Personas.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Persona persona) =>
            await _context.Personas.InsertOneAsync(persona);
    }
}
