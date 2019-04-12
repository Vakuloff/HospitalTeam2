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
    public class Department
    {
        [Key, ScaffoldColumn(false)]
        public int DepartmentID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string DepartmentTitle { get; set; }

       

        //one department has many jobs
        [InverseProperty("Department")]
        public List<JobPosting> JobPostings { get; set; }



        //one department has one hospital
        [ForeignKey("Hospital")]
        public int HospitalID { get; set; }

        public virtual Hospital Hospital { get; set; }

        //one department has many staff
        public IEnumerable<Staff> Staff { get; set; }
    }
}
