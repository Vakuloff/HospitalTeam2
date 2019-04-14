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

        [Required, StringLength(255), Display(Name = "JobPosting Title")]
        public string JobPostingTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Type")]
        public string JobPostingType { get; set; } //This talks about partime, fulltime, etc.

        [DataType(DataType.Text), Display(Name = "Description")]
        public string JobPostingDesc { get; set; }

        [DataType(DataType.Text), Display(Name = "Requirements")]
        public string JobPostingReq { get; set; }


        // job has one hospital
        public virtual Hospital Hospital { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalID { get; set; }

        //job has one department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public IEnumerable<JobApplication> JobApplications { get; set; }
    }
}
