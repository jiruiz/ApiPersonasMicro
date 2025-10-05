using Business.Api.Data;
using Business.Api.Dto;
using Business.Api.Interfaces;
using Business.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace Business.Api.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DataContext _context;

        public BusinessRepository(DataContext context)
        {
            _context = context;
        }

        // ✅ Obtener todos los negocios
        public ICollection<BusinessDto> GetBusinesses()
        {
            return _context.Businesses
                .Select(b => new BusinessDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Industry = b.Industry,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    TaxId = b.TaxId,
                    VATStatus = b.VATStatus,
                    LegalName = b.LegalName,
                    StartOfActivities = b.StartOfActivities,
                    YearsInIndustry = b.YearsInIndustry,
                    Street = b.Street,
                    City = b.City,
                    State = b.State
                })
                .ToList();
        }

        // ✅ Agregar un nuevo negocio
        public bool AddBusiness(BusinessDto businessDto)
        {
            var business = new Models.Business
            {
                Name = businessDto.Name,
                Industry = businessDto.Industry,
                PhoneNumber = businessDto.PhoneNumber,
                Email = businessDto.Email,
                TaxId = businessDto.TaxId,
                VATStatus = businessDto.VATStatus,
                LegalName = businessDto.LegalName,
                StartOfActivities = businessDto.StartOfActivities,
                YearsInIndustry = businessDto.YearsInIndustry,
                Street = businessDto.Street,
                City = businessDto.City,
                State = businessDto.State
            };

            _context.Businesses.Add(business);
            return Save();
        }

        // ✅ Guardar cambios en la BD
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        // ✅ Obtener un negocio por ID
        public Models.Business GetBusinessById(int id)
        {
            return _context.Businesses.FirstOrDefault(b => b.Id == id);
        }


        // ✅ Obtener negocios por rubro
        public ICollection<BusinessDto> GetBusinessesByIndustry(string industry)
        {
            return _context.Businesses
                .Where(b => b.Industry == industry)
                .Select(b => new BusinessDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Industry = b.Industry,
                    PhoneNumber = b.PhoneNumber,
                    Email = b.Email,
                    TaxId = b.TaxId,
                    VATStatus = b.VATStatus,
                    LegalName = b.LegalName,
                    StartOfActivities = b.StartOfActivities,
                    YearsInIndustry = b.YearsInIndustry,
                    Street = b.Street,
                    City = b.City,
                    State = b.State
                })
                .ToList();
        }
    }
}
