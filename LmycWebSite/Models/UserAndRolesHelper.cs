using LmycDataLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LmycWebSite.Models
{
    public class UserAndRolesHelper
    {
        public List<UserMembers> FirstTable { get; set; }
        public List<AppRole> SecondTable { get; set; }
    }
}