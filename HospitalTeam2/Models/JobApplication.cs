﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalTeam2.Models
{
    public class JobApplication
    {
        [Key, ScaffoldColumn(false)]
        public int JobApplicationID { get; set; }


        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required, StringLength(255), Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; }

        [Required, StringLength(255), Display(Name = "Resume")]
        public string Resume { get; set; }

        //we decided that a jobposting is for one job only
        public virtual JobPosting JobPosting { get; set; }

        [ForeignKey("JobPosting")]
        public int JobPostingID { get; set; }

      


    }
}
