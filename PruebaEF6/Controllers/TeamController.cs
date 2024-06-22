using PruebaEF6.Models;
using PruebaEF6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class TeamController : Controller
    {
        private TeamRepository teamRepository = new TeamRepository();
        private LeagueRepository leagueRepository = new LeagueRepository();

        public async Task<ActionResult> Index()
        {
            List<Team> teams = await teamRepository.GetTeams();
            return View(teams);
        }

        public async Task<ActionResult> Edit(int id)
        {
            IEnumerable<League> leagues = await leagueRepository.GetLeagues();
            ViewBag.Leagues = leagues.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            Team team = await teamRepository.GetById(id);
            return View(team);
        }

        public async Task<ActionResult> Create()
        {
            IEnumerable<League> leagues = await leagueRepository.GetLeagues();
            ViewBag.Leagues = leagues.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            Team team = new Team();
            return View(team);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTeam(Team team)
        {
            await teamRepository.Create(team);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditTeam(Team team)
        {
            await teamRepository.Edit(team);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            Team team = await teamRepository.GetById(id);
            return View(team);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await teamRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}