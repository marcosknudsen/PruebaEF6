using PruebaEF6.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace PruebaEF6.Repository
{
    public class CountryRepository
    {
        private readonly PROMIEDOS_BASQUET_NETEntities _context = new PROMIEDOS_BASQUET_NETEntities();

        public async Task AddCountry(Country country)
        {
            _context.Country.Add(country);
            await _context.SaveChangesAsync();
        }

        public async Task EditCountry(Country country)
        {
            _context.Country.AddOrUpdate(country);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountry(int id)
        {
            Country country = await _context.Country.FindAsync(id);
            _context.Country.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }

        public async Task<Country> GetCountry(int id)
        {
            return await _context.Country.FindAsync(id);
        }
    }
}