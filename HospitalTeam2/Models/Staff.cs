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


        //one doctor has many bookingrequests
        public IEnumerable<BookingRequest> BookingRequests { get; set; }

        //position
        //department
    }
}
