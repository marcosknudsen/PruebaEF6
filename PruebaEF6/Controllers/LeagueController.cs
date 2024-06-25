using PruebaEF6.Models;
using PruebaEF6.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class LeagueController : Controller
    {
        private readonly LeagueRepository leagueRepository = new LeagueRepository();
        private readonly CountryRepository countryRepository = new CountryRepository();
        private readonly TeamRepository teamRepository = new TeamRepository();

        public async Task<ActionResult> Index()
        {
            var leagues = await leagueRepository.GetLeagues();
            return View(leagues);
        }

        public async Task<ActionResult> Create()
        {
            League league = new League();

            List<SelectListItem> leagues = (await countryRepository.GetCountries()).ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                };
            });

            ViewBag.Countries = leagues;

            return View(league);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeague(League league)
        {
            await leagueRepository.Create(league);
            return RedirectToAction(actionName: "Index", controllerName: "League");
        }

        public async Task<ActionResult> Edit(int id)
        {
            League league=await leagueRepository.GetById(id);

            List<SelectListItem> leagues = (await countryRepository.GetCountries()).ConvertAll(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                };
            });

            ViewBag.Countries = leagues;

            return View(league);
        }

        [HttpPost]
        public async Task<ActionResult> EditLeague(League league)
        {
            await leagueRepository.Edit(league);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            League league = await leagueRepository.GetById(id);
            return View(league);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteLeague(int id)
        {
            var league = await leagueRepository.GetById(id);
            var teams = await teamRepository.GetByLeague(id);

            if (league == null)
            {
                return RedirectToAction("NotFound");
            }

            foreach (var team in teams)
            {
                await teamRepository.Delete(team.Id);
            }

            await leagueRepository.Delete(league);
            return RedirectToAction("Index");
        }
    }
}