using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LmycDataLib.Models;
using LmycWebSite.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LmycWebSite.Controllers
{
    public class UserMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserMembers
        public ActionResult Index()
        {
            //Get the list of Roles
            UserAndRolesHelper viewModel = new UserAndRolesHelper();
            viewModel.FirstTable = db.UserMembers.ToList();
            viewModel.SecondTable = db.AppRole.ToList();
            if (TempData["RoleError"] != null) { 
                ViewBag.RoleError = TempData["RoleError"].ToString();
            } else if (TempData["RoleSuccess"] != null) {
                ViewBag.RoleSuccess = TempData["RoleSuccess"].ToString();
            } else if (TempData["UserError"] != null) {
                ViewBag.UserError = TempData["UserError"].ToString();
            } else if (TempData["UserSuccess"] != null) {
                ViewBag.UserSuccess = TempData["UserSuccess"].ToString();
            }
            return View(viewModel);
        }

        // GET: UserMembers/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.roleName = new SelectList(db.AppRole, "roleName", "roleName");
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

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                if (!UserManager.IsInRole(userMembers.Id, userMembers.Role))
                {
                    UserManager.AddToRole(userMembers.Id, userMembers.Role);
                    TempData["UserSuccess"] = "User successfully added to role";
                } else
                {
                    TempData["UserError"] = "User already in that role";
                }

                return RedirectToAction("Index");
            }
            return View(userMembers);
        }


        // GET: UserMembers/Delete/5
        public ActionResult Delete(string id)
        {
            ViewBag.roleName = new SelectList(db.AppRole, "roleName", "roleName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id == "" + 1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
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
        public ActionResult DeleteConfirmed([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,Firstname,LastName,Street,City,Province,PostalCode,Country,MobileNumber,SailingExperience,Role")] UserMembers userMembers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMembers).State = EntityState.Modified;
                db.SaveChanges();

                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                if (UserManager.IsInRole(userMembers.Id, userMembers.Role))
                {
                    UserManager.RemoveFromRole(userMembers.Id, userMembers.Role);
                    TempData["UserSuccess"] = "User successfully removed from role";
                } else
                {
                    TempData["UserError"] = "User was not in that role";
                }

                return RedirectToAction("Index");
            }
            return View(userMembers);
            //UserMembers userMembers = db.UserMembers.Find(id);
            //db.Users.Remove(userMembers);
            //db.SaveChanges();
            //return RedirectToAction("Index");
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
