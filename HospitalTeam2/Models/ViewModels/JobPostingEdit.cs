using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class JobPostingEdit
    {
        public JobPostingEdit()
        {

        }
        // list of hospitals

        public virtual JobPosting JobPostings { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }

    }

    
}
