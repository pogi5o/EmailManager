using EmailManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmailManager.Controllers {
    public class CustomerManagerController : Controller {
        private AppDbContext db = null;
        public CustomerManagerController(AppDbContext db) {
            this.db = db;
        }

        public IActionResult List() {
            List<Customer> model = (from c in db.Customers
                                    orderby c.CustomerNo
                                    select c).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Insert() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(Customer model) {
            if (ModelState.IsValid) {
                db.Customers.Add(model);
                db.SaveChanges();
                ViewBag.Message = "Customer added successfully";
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(string id) {
            var model = db.Customers.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Customer model) {
            if (ModelState.IsValid) {
                db.Customers.Update(model);
                db.SaveChanges();
                ViewBag.Message = "Customer updated successfully";
            }

            return View(model);
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(string id) {
            var model = db.Customers.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string id) {
            var model = db.Customers.Find(id);
            db.Customers.Remove(model);
            db.SaveChanges();
            TempData["Message"] = "Employee Deleted Successfully";
            return RedirectToAction("List");
        }
    }
}
