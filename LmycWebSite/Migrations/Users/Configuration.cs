namespace LmycWebSite.Migrations.Users
{
    using LmycDataLib.Models;
    using LmycWebSite.Data;
    using LmycWebSite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LmycDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Users";
            ContextKey = "LmycWebSite.Models.ApplicationDbContext";
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
            //context.UserMembers.AddOrUpdate(
            //    u => u.Id, DummyData.getUsers().ToArray());
            //context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var role = new IdentityRole();
            role.Name = "Admin";
            roleManager.Create(role);

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
                SailingExperience = "SailingExperience",
                Role = "Admin",
            };
            var result = UserManager.Create(user, "P@$$w0rd");
            var result1 = UserManager.AddToRole("1", "Admin");

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
                SailingExperience = "SailingExperience",
                Role = "Member",
            };
            var result3 = UserManager.Create(user, "P@$$w0rd");
            

            role = new IdentityRole();
            role.Name = "Member";
            roleManager.Create(role);

            var result4 = UserManager.AddToRole("2", "Member");

            //context.Boats.AddOrUpdate(
            //    b => b.BoatId, DummyData.getBoats(context).ToArray());

            context.SaveChanges();
        }
    }
}
