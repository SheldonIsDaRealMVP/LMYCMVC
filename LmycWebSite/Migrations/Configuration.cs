namespace LmycWebSite.Migrations
{
    using LmycDataLib.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LmycDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        public static List<Boat> getBoats(ApplicationDbContext context)
        {
            var dateTime = DateTime.Now;
            string dateFormat = dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            List<Boat> boats = new List<Boat>()
            {
                new Boat()
                {
                    BoatId = 1,
                    BoatName = "Boaty McBoatface",
                    Picture = "boaty.jpeg",
                    LengthInFeet = 50,
                    Make = "Speedboat",
                    Year = 2014,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "1",
                },
                new Boat()
                {
                    BoatId = 2,
                    BoatName = "Boaty McBoatface Jr.",
                    Picture = "boatyjr.jpeg",
                    LengthInFeet = 35,
                    Make = "Medium Speedboat",
                    Year = 2016,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "1",
                },
                new Boat()
                {
                    BoatId = 3,
                    BoatName = "Boaty McBoatface Sr.",
                    Picture = "boatysr.jpeg",
                    LengthInFeet = 70,
                    Make = "Maximum Speedboat",
                    Year = 2004,
                    RecordCreationDate = dateFormat,
                    CreatedBy = "2",
                }
            };

            return boats;
        }

        public static List<AppRole> getRoles(ApplicationDbContext context)
        {
            List<AppRole> Roles = new List<AppRole>()
            {
                new AppRole()
                {
                    roleName = "Admin",
                },
                new AppRole()
                {
                    roleName = "Member",
                },
            };

            return Roles;
        }

        protected override void Seed(LmycDataLib.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.AppRole.AddOrUpdate(t => t.roleName, getRoles(context).ToArray());

            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            var user = new UserMembers
            {
                Id = "1",
                UserName = "a",
                Email = "a@a.a",
                Street = "Street",
                City = "City",
                Province = "Province",
                Country = "Country",
                MobileNumber = "MobileNumber",
                SailingExperience = 9,
                Role = "Admin",
            };
            var result = UserManager.Create(user, "P@$$w0rd");
            if (!UserManager.IsInRole("1", "Admin"))
            {
                var result1 = UserManager.AddToRole("1", "Admin");
            }

            if (!roleManager.RoleExists("Member"))
            {
                var role = new IdentityRole();
                role.Name = "Member";
                roleManager.Create(role);
            }
            user = new UserMembers
            {
                Id = "2",
                UserName = "m",
                Email = "m@m.m",
                Street = "Street",
                City = "City",
                Province = "Province",
                Country = "Country",
                MobileNumber = "MobileNumber",
                SailingExperience = 6,
                Role = "Member",
            };
            var result3 = UserManager.Create(user, "P@$$w0rd");

            if (!UserManager.IsInRole("2", "Member"))
            {
                var result4 = UserManager.AddToRole("2", "Member");
            }

            context.Boats.AddOrUpdate(t => t.BoatId, getBoats(context).ToArray());

            context.SaveChanges();
        }
    }
}
