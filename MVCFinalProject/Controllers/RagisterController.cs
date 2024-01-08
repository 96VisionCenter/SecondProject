using MVCFinalProject.Data;
using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFinalProject.Controllers
{
    public class RagisterController : Controller
    {
        private readonly ApplicationDbContext context;
        public RagisterController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Ragister
        public ActionResult Index()
        {
            var userList = context.Ragisters.Include(r => r.City).Include(r => r.City.State).Include(r => r.City.State.Country).ToList();
            return View(userList);
        }
        public ActionResult upsert(int ? id)
        {
            ViewBag.Countrylist = context.countries.ToList();
            ViewBag.StateList = context.States.ToList();
            ViewBag.CityList = context.cities.ToList();
            Ragister ragister = new Ragister();
            if (id == null) return View(ragister);
            // edit
            ragister = context.Ragisters.Find(id);
            if (ragister == null) return HttpNotFound();
            ragister.Stateid = ragister.City.State.id;
            ragister.Countryid = ragister.City.State.Country.id;

            return View(ragister);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult upsert(Ragister ragister)
        {
            if (ragister == null) return HttpNotFound();
            ViewBag.Countrylist = context.countries.ToList();
            ViewBag.StateList = context.States.ToList();
            ViewBag.CityList = context.cities.ToList();
            if (ModelState.IsValid) return View(ragister);
            if (ragister.id == 0)
                context.Ragisters.Add(ragister);
            else
            {
                var userInDb = context.Ragisters.Find(ragister.id);
                if (userInDb == null) return HttpNotFound();
                userInDb.Name = ragister.Name;
                userInDb.Address = ragister.Address;
                userInDb.Email = ragister.Email;
                userInDb.Gender = ragister.Gender;
                userInDb.Subscribe = ragister.Subscribe;
                userInDb.Cityid = ragister.Cityid;
            }
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details( int id)
        {
            var UserInDb = context.Ragisters.Include(u => u.City).Include(u => u.City.State).Include(u => u.City.State.Country).FirstOrDefault(u => u.id==id);
            if (UserInDb == null) return HttpNotFound();
            return View(UserInDb);
        }
        #region APIs
        private List<State> GetStates(int countryid)
        {
            return context.States.Where(s => s.Countryid == countryid).ToList();

        }
        private List<City>GetCities(int stateid)
        {
            return context.cities.Where(s => s.Stateid == stateid).ToList();

        }
        public ActionResult LoadStateByCountry(int stateid)
        {
            var statelist=GetStates(countryid)
        }

    }
    #endregion
}