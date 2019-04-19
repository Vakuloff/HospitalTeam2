using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class ScheduleEdit
    {
        public virtual Schedule Schedules { get; set; }
        public IEnumerable<Staff> Staffs { get; set; }
    }
}
