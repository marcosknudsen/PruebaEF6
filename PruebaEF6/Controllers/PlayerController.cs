using PruebaEF6.Models;
using PruebaEF6.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class PlayerController : Controller
    {
        private readonly PlayerRepository playerRepository = new PlayerRepository();
        private readonly CountryRepository countryRepository = new CountryRepository();
        public async Task<ActionResult> Index()
        {
            List<Player> players = await playerRepository.GetPlayers();
            return View(players);
        }
        public async Task<ActionResult> Delete(int id)
        {
            Player player = await playerRepository.GetPlayerById(id);
            return View(player);
        }

        [HttpPost]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            await playerRepository.DeletePlayer(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Countries = (await countryRepository.GetCountries()).Select(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                };
            });
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreatePlayer(Player player)
        {
            await playerRepository.Create(player);
            return RedirectToAction("Index");
        }
    }
}