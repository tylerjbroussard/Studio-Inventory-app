using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StudioInventory.Models;

namespace StudioInventory.Controllers
{
    public class HomeController : Controller
    {
        private InventoryEntities _db = new InventoryEntities();

        //Get: Home/Index
        public ActionResult Index()
        {
            return View(_db.Inventories.ToList());

        }

        //Get: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemCode,Description,Cost,Vendor")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _db.Inventories.Add(inventory);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        //Get: Home/Edit
        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemCode,Description,Cost,Vendor")] Inventory inventory)
        {

            if (ModelState.IsValid)
            {
                _db.Entry(inventory).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inventory _inventory = _db.Inventories.Find(id);

            if (_inventory == null)
            {
                return HttpNotFound();
            }
            return View(_inventory);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory _inventory = _db.Inventories.Find(id);
            _db.Inventories.Remove(_inventory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            return View(_db.Inventories.Find(id));

        }
    }
}