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
    }
}