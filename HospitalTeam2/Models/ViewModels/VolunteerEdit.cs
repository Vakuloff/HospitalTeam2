using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalTeam2.Models.ViewModels
{
    public class VolunteerEdit
    {
        public VolunteerEdit()
        {

        }
        // list of volunteer

        public virtual Volunteer Volunteer { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }
    }

}
