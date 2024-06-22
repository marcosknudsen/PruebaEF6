using PruebaEF6.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PruebaEF6.Repository
{
    public class PlayerRepository
    {
        private readonly PROMIEDOS_BASQUET_NETEntities _context = new PROMIEDOS_BASQUET_NETEntities();

        public async Task<List<Player>> GetPlayers()
        {
            return await _context.Player.ToListAsync();
        }

        public async Task DeletePlayer(int id)
        {
            Player playerFound = await _context.Player.FirstOrDefaultAsync(player => player.Id == id);

            _context.Player.Remove(playerFound);
            _context.SaveChanges();
        }

        public async Task<Player> GetPlayerById(int id)
        {
            return await _context.Player.FirstOrDefaultAsync(player=>player.Id==id);       
        }

        public async Task Create(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();
        }
    }
}