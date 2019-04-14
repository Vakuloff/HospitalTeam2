using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class JobApplicationEdit
    {
        public virtual JobApplication JobApplications { get; set; }

        public IEnumerable<JobPosting> JobPostings { get; set; }

    }
}
