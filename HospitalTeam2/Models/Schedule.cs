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
    public class Schedule
    {
        [Key, ScaffoldColumn(false)]
        public int ScheduleId { get; set; }

        //does timestamp store it in unix time?
        //if yes -- just convert it to D m y H: is 
        //if no -- find another data type

        [Required, Timestamp, Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required, Timestamp, Display(Name = "StartShift")]
        public DateTime StartShift { get; set; }

        [Required, Timestamp, Display(Name = "EndShift")]
        public DateTime EndShift { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public virtual Staff Staff { get; set; }


    }
}
