using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LmycDataLib.Models
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

        /*[ScaffoldColumn(false)]
        [Column(TypeName="Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RecordCreationDate { get; set; }*/

        public string RecordCreationDate { get; set; }

        [ForeignKey("User")]
        [ScaffoldColumn(false)]
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public ApplicationUser User { get; set; }
    }
}