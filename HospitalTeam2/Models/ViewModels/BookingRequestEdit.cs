using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalTeam2.Models.ViewModels
{
    public class BookingRequestEdit
    {
        public virtual BookingRequest BookingRequest { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }

        public IEnumerable<Staff> Staffs { get; set; }
    }
}
