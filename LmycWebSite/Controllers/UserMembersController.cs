using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LmycDataLib.Models.UserMembers;
using LmycWebSite.Models;

namespace LmycWebSite.Controllers
{
    public class UserMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserMembers
        public ActionResult Index()
        {
            return View(db.UserMembers.ToList());
        }

        // GET: UserMembers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMembers userMembers = db.UserMembers.Find(id);
            if (userMembers == null)
            {
                return HttpNotFound();
            }
            return View(userMembers);
        }

        // GET: UserMembers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Role")] UserMembers userMembers)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(userMembers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userMembers);
        }

        // GET: UserMembers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMembers userMembers = db.UserMembers.Find(id);
            if (userMembers == null)
            {
                return HttpNotFound();
            }
            return View(userMembers);
        }

        // POST: UserMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Role")] UserMembers userMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMembers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMembers);
        }

        // GET: UserMembers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMembers userMembers = db.UserMembers.Find(id);
            if (userMembers == null)
            {
                return HttpNotFound();
            }
            return View(userMembers);
        }

        // POST: UserMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserMembers userMembers = db.UserMembers.Find(id);
            db.Users.Remove(userMembers);
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
