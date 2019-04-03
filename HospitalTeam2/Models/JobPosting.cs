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

        [Required, StringLength(255), Display(Name = "HospitalTitle")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string JobPostingTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Type")]
        public string JobPostingType { get; set; } //This talks about partime, fulltime, etc.

        [StringLength(int.MaxValue), Display(Name = "Description")]
        public string JobPostingDesc { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Requirements")]
        public string JobPostingReq { get; set; }
    }
}
