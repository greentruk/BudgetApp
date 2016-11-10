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
using System.Threading.Tasks;

namespace BudgetApp.Models.CodeFirst
{
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Landing
        public ActionResult Landing()
        {
            return View();
        }

        // GET: HouseholdDashboard
        public ActionResult HouseholdDashboard()
        {
            return View();
        }



        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var userHousehold = user.Household;
            Household household = new Household();

            if (userHousehold != null)
            {
                return View(userHousehold);
            }
            foreach (var invitee in db.HouseholdInvitations )
            {
                if (user.Email == invitee.Email && invitee.EmailUsed  == false)
                {
                    return RedirectToAction("Invitations", new { id = invitee.HouseholdId });
                }
            }

            return RedirectToAction("Create");
        }


        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

       

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateHousehold([Bind(Include = "Name")] Household household)
        {
            if (ModelState.IsValid)
            {
                household.Create = DateTimeOffset.Now;
                db.Households.Add(household);
                db.SaveChanges();
                
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);
                var thisHousehold = db.Households.Find(household.Id);
                thisHousehold.Users.Add(user);
                return RedirectToAction("UserDashboard");
            }

            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }
        // GET: Households/UserDashboard
        public ActionResult UserDashboard()
        {
            return View();
        }

        // GET: Households/Invitations
        public ActionResult Invitations(int id)
        {
            Household household = db.Households.Find(id);
            var user = db.Users.Find(User.Identity.GetUserId());
            ViewBag.id = id;
            return View(household);
        }

        // POST: Households/Invitations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcceptInvitation(int id)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            Household household = db.Households.Find(id);
            household.Users.Add(user);

            var thisInvitation = db.HouseholdInvitations.SingleOrDefault(i => i.Email == user.Email);
            thisInvitation.EmailUsed = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Households/Invitations
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeclineInvitation(int id)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            Household household = db.Households.Find(id);

            var thisInvitation = household.Invitations.SingleOrDefault(i => i.Email == user.Email);
            thisInvitation.EmailUsed = true;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // POST: Households/Invite
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Invite(string InvitedEmail)
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var userHousehold = user.Household;
            HouseholdInvitation householdInvitation = new HouseholdInvitation();

            householdInvitation.Email = InvitedEmail;
            householdInvitation.HouseholdId = userHousehold.Id;

            if (db.HouseholdInvitations.Contains(householdInvitation))
            {
                return RedirectToAction("IniviteError");
            }

            db.HouseholdInvitations.Add(householdInvitation);
            userHousehold.Invitations.Add(householdInvitation);
            db.SaveChanges();

            var svc = new EmailService();
            var msg = new IdentityMessage();
            msg.Destination = InvitedEmail;
            msg.Subject = "You have been asked to Join " + user.DisplayName + "'s Household, " + userHousehold.Name;
            msg.Body = "You have been asked to join " + user.DisplayName + "'s household in the Budget application. Please register, then click the Household link to join.";
            await svc.SendAsync(msg);

            return RedirectToAction("Index");
        }


        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
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
    }
}
