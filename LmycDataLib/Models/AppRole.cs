using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LmycDataLib.Models
{
    public class AppRole
    {
        [Key]
        public string roleName { get; set; }

    }
}