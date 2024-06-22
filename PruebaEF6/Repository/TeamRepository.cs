using PruebaEF6.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaEF6.Repository
{
    public class TeamRepository
    {
        private readonly PROMIEDOS_BASQUET_NETEntities _context = new PROMIEDOS_BASQUET_NETEntities();
        public async Task<List<Team>> GetTeams()
        {
            return await _context.Team.ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await _context.Team.Include("Player").FirstOrDefaultAsync((team) => team.Id == id);
        }

        public async Task<List<Team>> GetByLeague(int id)
        {
            return await _context.Team.Where(x=>x.League_Id == id).ToListAsync();
        }

        public async Task Delete(int id)
        {
            var existingTeam = await _context.Team.FirstOrDefaultAsync((team) => team.Id == id);

            _context.Team.Remove(existingTeam);
            _context.SaveChanges();
        }

        public async Task Edit(Team team)
        {
            var foundTeam = await _context.Team.FirstOrDefaultAsync(p => p.Id == team.Id);
            foundTeam.Name = team.Name;
            foundTeam.League_Id = team.League.Id;
            _context.Team.AddOrUpdate(foundTeam);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Team team)
        {
            _context.Team.Add(team);
            await _context.SaveChangesAsync();
        }
    }
}