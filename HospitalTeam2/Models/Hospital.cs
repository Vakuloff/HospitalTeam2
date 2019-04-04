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
    public class Hospital
    {
        [Key, ScaffoldColumn(false)]
        public int HospitalID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Address")]
        public string Address { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(int.MaxValue), Display(Name = "DepartmentTitle")]
        public string DepartmentTitle { get; set; }
      

        //Hospital and Job Positions
        [InverseProperty("Hospital")]
        public List<JobPosting> JobPostings { get; set; }

        //one hospital has many departments
        public IEnumerable<Department> Departments { get; set; }

        //one hospital has many volunteers
        public IEnumerable<Volunteer> Volunteers { get; set; }

        //one hospital has many bookingrequests
        public IEnumerable<BookingRequest> BookingRequests { get; set; }


        //foreign key
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Volunteer")]
        public int VolunteerID { get; set; }

        [ForeignKey("JobPosting")]
        public int JobPostingID { get; set; }

        [ForeignKey("BokingRequest")]
        public int BookingID { get; set; }

    }
}

