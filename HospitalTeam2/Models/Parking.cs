using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalTeam2.Models
{
    public class Parking
    {
        [Key]
        public int ParkingID { get; set; }

        [Required, StringLength(30), Display(Name = "Name")]
        public string VisitorName { get; set; }

        [Required, StringLength(30), Display(Name = "Car Number")]
        public string VisitoCarNo { get; set; }

        [Required, StringLength(255), Display(Name = "Purpose of Visit")]
        public string ParkingPurpose { get; set; }

        [Required, StringLength(30), Display(Name = "Contact")]
        public string ParkingContact { get; set; }

        public virtual Hospital hospital { get; set; }
    }
}
