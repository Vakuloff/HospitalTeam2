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
    public class JobPosting
    {
        [Key, ScaffoldColumn(false)]
        public int JobPostingID { get; set; }


        // QUESTION FOR GROUP: IS SOMEONE DOING DEPARTMENTS?
        //job application doesn't have a title, a job application has a hospital and a hospital has a title
        //[Required, StringLength(255), Display(Name = "HospitalTitle")]
        //public string HospitalTitle { get; set; }

        //job application doesn[t have a department title, a job application has a department and a department has a departmenttitle
        //[Required, StringLength(255), Display(Name = "DepartmentTitle")]
        //public string DepartmentTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string JobPostingTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Type")]
        public string JobPostingType { get; set; } //This talks about partime, fulltime, etc.

        [DataType(DataType.Text), Display(Name = "Description")]
        public string JobPostingDesc { get; set; }

        [DataType(DataType.Text), Display(Name = "Requirements")]
        public string JobPostingReq { get; set; }

        /* you cant have a foreign key when you are associating this job posting with many other things*/

        //[StringLength(int.MaxValue), Display(Name = "JobApplicationID")]
        //public string JobApplicationID { get; set; }

        //a job position has many applications
        public virtual IEnumerable<JobApplication> JobApplications { get; set; }


        // job has one hospital
        public virtual Hospital Hospital { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalID { get; set; }

        //job has one department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }


    }
}
