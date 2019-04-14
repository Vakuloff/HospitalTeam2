using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class DepartmentEdit
    {

        //one thing I need to know when editing a department
        //I need to know all the hospitals so that the user can pick one\

        public IEnumerable<Hospital> Hospitals { get; set; }
        public Department Departments { get; set; }
    }
}
