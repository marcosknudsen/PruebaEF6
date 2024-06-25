﻿using PruebaEF6.Models;
using PruebaEF6.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class TeamController : Controller
    {
        private TeamRepository teamRepository = new TeamRepository();
        private LeagueRepository leagueRepository = new LeagueRepository();
        private CountryRepository countryRepository = new CountryRepository();

        public async Task<ActionResult> Index()
        {
            List<Team> teams = await teamRepository.GetTeams();
            return View(teams);
        }

        public async Task<ActionResult> Edit(int id)
        {
            IEnumerable<Country> countries = await countryRepository.GetCountries();
            ViewBag.Countries = countries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            Team team = await teamRepository.GetById(id);
            return View(team);
        }

        public async Task<ActionResult> Create()
        {
            IEnumerable<Country> countries = await countryRepository.GetCountries();
            ViewBag.Countries = countries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
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

        [HttpPost]
        public async Task<JsonResult> GetLeaguesByCountry(int id)
        {
            var leagues= (await leagueRepository.GetLeaguesByCountry(id)).Select(x =>
            {
                return new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                };
            });

            return Json(leagues);
        }
    }
}