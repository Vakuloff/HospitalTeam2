﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, Display(Name = "LastName")]
        public string LastName { get; set; }

        public string StatusMessage { get; set; }

        public List<string> Roles { get; set; }

        [Required, Display(Name = "Hospital Name")]
        public string Hospital { get; set; }
    }
}
