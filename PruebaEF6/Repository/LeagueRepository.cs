using PruebaEF6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PruebaEF6.Repository
{
    public class LeagueRepository
    {
        private readonly PROMIEDOS_BASQUET_NETEntities _context=new PROMIEDOS_BASQUET_NETEntities();

        public async Task<List<League>> GetLeagues()
        {
            return await _context.League.Include(x=>x.Country).ToListAsync();
        }

        public async Task<League> GetById(int id)
        {
            return await _context.League.Include(x=>x.Country).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(League league)
        {
            _context.League.Add(league);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(League league)
        {
            _context.League.Remove(league);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(League league)
        {
            _context.League.AddOrUpdate(league);
            await _context.SaveChangesAsync();
        }

        public async Task<List<League>> GetLeaguesByCountry(int countryId)
        {
            return await _context.League.Where(x => x.Country_Id == countryId).ToListAsync();
        }
    }
}