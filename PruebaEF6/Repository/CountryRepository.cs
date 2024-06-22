using PruebaEF6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PruebaEF6.Repository
{
    public class CountryRepository
    {
        private readonly PROMIEDOS_BASQUET_NETEntities _context = new PROMIEDOS_BASQUET_NETEntities();

        public async Task<List<Country>> GetCountries()
        {
            return await _context.Country.ToListAsync();
        }
    }
}