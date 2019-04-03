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
    public class BookingRequest
    {
        [Key, ScaffoldColumn(false)]
        public int BookingID { get; set; }

        [Required, StringLength(255), Display(Name = "HospitalTitle")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "TypeDoctor")]
        public string TypeDoctor { get; set; }

        [Required, StringLength(255), Display(Name = "DoctorName")]
        public string DoctorName { get; set; }

        [Required, StringLength(255), Display(Name = "Reason")]
        public string Reason { get; set; }

        [Required, StringLength(255), Display(Name = "Date")]
        public string Date { get; set; }

        [Required, StringLength(255), Display(Name = "Time")]
        public string Time { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required, StringLength(255), Display(Name = "Age")]
        public string Age { get; set; }
    }
}
