using LmycWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LmycDataLib.Models.Boat
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }

        [Display(Name = "Name")]
        public string BoatName { get; set; }

        public string Picture { get; set; }

        [Display (Name = "Length")]
        public double LengthInFeet { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        [Column(TypeName="Date")]
        public DateTime RecordCreationDate { get; set; }

        public int Id { get; set; }
        public ApplicationUser CreatedBy { get; set; }
    }
}