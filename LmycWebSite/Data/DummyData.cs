using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LmycDataLib.Models.UserMembers;
using LmycDataLib.Models.Boat;

namespace LmycWebSite.Data
{
    public class DummyData
    {
        public static System.Collections.Generic.List<UserMembers> getUsers()
        {
            List<UserMembers> Users = new List<UserMembers>()
            {
                new UserMembers()
                {
                    Id = "c5e4fce3-e5a8-4352-b8c9-a25788012d12",
                    UserName = "a",
                    Email = "a@a.a",
                    Street = "Street",
                    City = "City",
                    Province = "Province",
                    Country = "Country",
                    MobileNumber = "MobileNumber",
                    SailingExperience = "SailingExperience",
                    Role = "Admin",
                    PasswordHash = "668eb21f-6d62-491b-b06f-7f2a88afff46"
                },
                new UserMembers()
                {
                    Id = "c5e4fce3-e5a8-4352-b8c9-a25788012d13",
                    UserName = "m",
                    Email = "m@m.m",
                    Street = "Street",
                    City = "City",
                    Province = "Province",
                    Country = "Country",
                    MobileNumber = "MobileNumber",
                    SailingExperience = "SailingExperience",
                    Role = "Member",
                    PasswordHash = "668eb21f-6d62-491b-b06f-7f2a88afff46",
                }
            };

            return Users;
        }
        public static System.Collections.Generic.List<Boat> getBoats(Models.ApplicationDbContext context)
        {
            List<Boat> Boats = new List<Boat>()
            {
                new Boat() {
                    BoatId = 1,
                    BoatName = "Duck",
                    Picture = "Somewhere",
                    LengthInFeet = 1.0,
                    Make = "Some Time",
                    Year = 1000,
                    RecordCreationDate = new DateTime(010201),
                    Id = 0,
                    CreatedBy = context.UserMembers.Find("c5e4fce3-e5a8-4352-b8c9-a25788012d12"),
                },
                new Boat() {
                    BoatId = 2,
                    BoatName = "Duck2",
                    Picture = "Somewher2e",
                    LengthInFeet = 2.0,
                    Make = "Some Time 2",
                    Year = 2000,
                    RecordCreationDate = new DateTime(010202),
                    Id = 1,
                    CreatedBy = context.UserMembers.Find("c5e4fce3-e5a8-4352-b8c9-a25788012d13"),
                },
            };

            return Boats;
        }
    }
}