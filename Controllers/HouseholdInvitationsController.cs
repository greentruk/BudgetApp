using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetApp.Models;
using BudgetApp.Models.CodeFirst;
using Microsoft.AspNet.Identity;

namespace BudgetApp.Controllers
{
    public class HouseholdInvitationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HouseholdInvitations
        public ActionResult Index()
        {
            return View(db.HouseholdInvitations.ToList());
        }

        // GET: HouseholdInvitations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInvitation householdInvitation = db.HouseholdInvitations.Find(id);
            if (householdInvitation == null)
            {
                return HttpNotFound();
            }
            return View(householdInvitation);
        }

        // GET: HouseholdInvitations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HouseholdInvitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InviteCode,HouseholdId")] HouseholdInvitation householdInvitation)
        {
            if (ModelState.IsValid)
            {
                db.HouseholdInvitations.Add(householdInvitation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           


            return View(householdInvitation);
        }

        // GET: HouseholdInvitations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInvitation householdInvitation = db.HouseholdInvitations.Find(id);
            if (householdInvitation == null)
            {
                return HttpNotFound();
            }
            return View(householdInvitation);
        }

        // POST: HouseholdInvitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InviteCode,HouseholdId")] HouseholdInvitation householdInvitation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(householdInvitation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(householdInvitation);
        }

        // GET: HouseholdInvitations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HouseholdInvitation householdInvitation = db.HouseholdInvitations.Find(id);
            if (householdInvitation == null)
            {
                return HttpNotFound();
            }
            return View(householdInvitation);
        }

        // POST: HouseholdInvitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HouseholdInvitation householdInvitation = db.HouseholdInvitations.Find(id);
            db.HouseholdInvitations.Remove(householdInvitation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Landing()
        {
            return View();
        }
    }
}
