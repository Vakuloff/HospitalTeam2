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
    public class Job
    {
        [Key, ScaffoldColumn(false)]
        public int JobID { get; set; }

        [Required, StringLength(255), Display(Name = "JobTitle")]
        public string JobTitle { get; set; }

        [Required, StringLength(255), Display(Name = "JobDescription")]
        public string JobDescription { get; set; }
    }
}
