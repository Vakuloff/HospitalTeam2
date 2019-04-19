using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class ContactFormEdit
    {
        public virtual ContactForm ContactForms { get; set; }
        public IEnumerable<Hospital> Hospitals { get; set; }
    }
}
