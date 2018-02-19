using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LmycDataLib.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LmycWebSite.Controllers
{
    public class AppRolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AppRoles
        public ActionResult Index()
        {
            return RedirectToRoute(new {controller = "UserMembers", action = "Index"});
        }

        // GET: AppRoles/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppRole appRole = db.AppRole.Find(id);
            if (appRole == null)
            {
                return HttpNotFound();
            }
            return View(appRole);
        }

        // GET: AppRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "roleName")] AppRole appRole)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

                if (!roleManager.RoleExists(appRole.roleName))
                {
                    db.AppRole.Add(appRole);
                    db.SaveChanges();
                    var role = new IdentityRole();
                    role.Name = appRole.roleName;
                    roleManager.Create(role);
                    TempData["RoleSuccess"] = "Role successfully created";
                } else
                {
                    TempData["RoleError"] = "Role already created";
                }
                return RedirectToAction("Index");
            }

            return View(appRole);
        }

        // GET: AppRoles/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppRole appRole = db.AppRole.Find(id);
            if (appRole == null)
            {
                return HttpNotFound();
            }
            return View(appRole);
        }

        // POST: AppRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                AppRole appRole = db.AppRole.Find(id);
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
                if (appRole.roleName != "Admin" && roleManager.RoleExists(appRole.roleName))
                {
                    var role = roleManager.FindByName(appRole.roleName);
                    roleManager.Delete(role);
                    db.AppRole.Remove(appRole);
                    db.SaveChanges();
                    TempData["RoleSuccess"] = "Successfully removed role and all members in that role";
                }


                return RedirectToAction("Index");
            } catch (Exception E)
            {
                TempData["RoleError"] = "Cannot delete while there are members in that role";
                return RedirectToAction("Index");
            }
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
