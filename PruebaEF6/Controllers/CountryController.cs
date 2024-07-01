using PruebaEF6.Models;
using PruebaEF6.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PruebaEF6.Controllers
{
    public class CountryController : Controller
    {
        private readonly CountryRepository countryRepository = new CountryRepository();

        public async Task<ActionResult> Index()
        {
            List<Country> countries= await countryRepository.GetCountries();
            return View(countries);
        }

        public ActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        public async Task<ActionResult> Edit(int id)
        {
            Country country = await countryRepository.GetCountry(id);
            return View(country);
        }

        public async Task<ActionResult> Delete(int id)
        {
            Country country = await countryRepository.GetCountry(id);
            return View(country);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCountry(Country country)
        {
            await countryRepository.AddCountry(country);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> EditCountry(Country country)
        {
            await countryRepository.EditCountry(country);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            await countryRepository.DeleteCountry(id);
            return RedirectToAction("Index");
        }
    }
}