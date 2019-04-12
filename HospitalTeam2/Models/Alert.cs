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
    public class Alert
    {
        [Key, ScaffoldColumn(false)]
        public int AlertId { get; set; }

        [Required, StringLength(255), Display(Name = "Alert Title")]
        public string AlertTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Alert Message")]
        public string AlertMessage { get; set; }
    }
}
