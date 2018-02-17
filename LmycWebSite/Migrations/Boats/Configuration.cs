namespace LmycWebSite.Migrations.Boats
{
    using LmycDataLib.Models;
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
            MigrationsDirectory = @"Migrations\Boats";
        }

        public static List<Boat> getBoats(ApplicationDbContext context)
        {
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
                    RecordCreationDate = DateTime.Now,
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
                    RecordCreationDate = DateTime.Now,
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
                    RecordCreationDate = DateTime.Now,
                    CreatedBy = "2",
                }
            };

            return boats;
        }

        protected override void Seed(LmycDataLib.Models.ApplicationDbContext context)
        {
            context.Boats.AddOrUpdate(t => t.BoatId, getBoats(context).ToArray());

            context.SaveChanges();
        }
    }
}
