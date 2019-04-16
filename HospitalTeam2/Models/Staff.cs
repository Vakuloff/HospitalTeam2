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
    public class Staff
    {
        [Key, ScaffoldColumn(false)]
        public int StaffId { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string StaffFirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string StaffLastName { get; set; }

        [Required, StringLength(255), Display(Name = "Type Doctor")]
        public string TypeDoctor { get; set; }


        //one staff has many shifts
        public IEnumerable<Schedule> schedules { get; set; }

        //one doctor has many bookingrequests
        public IEnumerable<BookingRequest> BookingRequests { get; set; }

        //one department has many staff
        [ForeignKey("DepartmentID")]
        public int DepartmentID { get; set; }

        public virtual Department Department { get; set; }
        //one hospital has many staff
        [ForeignKey("HospitalId")]
        public int HospitalId { get; set; }

        public virtual Hospital hospital { get; set; }

        //position
        //department
    }
}
