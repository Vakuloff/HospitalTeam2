using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class StaffEdit
    {
        public virtual Staff Staffs { get; set; }
        public IEnumerable<Hospital> Hospitals { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
