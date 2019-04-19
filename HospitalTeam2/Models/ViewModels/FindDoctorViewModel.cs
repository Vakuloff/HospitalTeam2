using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class FindDoctorViewModel
    {
        public List<Department> Departments { get; set; }

        public int[] DepartmentIds { get; set; }

        public List<Staff> Doctors { get; set; }


    }
}
