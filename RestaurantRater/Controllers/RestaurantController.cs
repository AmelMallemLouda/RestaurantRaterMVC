using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant
        public ActionResult Index()
        {
            return View(_db.Restaurants.ToList());
        }

        //Get: Restaurant/Create

        public ActionResult Create()
        {
            return View();
        }

        //Post:Resrtaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }
        //get:Restaurant/Delete/(ID)
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //Post:Resrtaurant/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {


            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
        //get:Restaurant/Edit/(ID)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }
        //Post:Resrtaurant/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);

        }
        //get:Restaurant/Details/(ID)
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

    }
}