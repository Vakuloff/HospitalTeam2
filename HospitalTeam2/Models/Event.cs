using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalNew.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required, StringLength(255), Display(Name = "Event Name")]
        public string EventName { get; set; }

        [Required, StringLength(255), Display(Name = "Event Description")]
        public string EventDescription { get; set; }

        [Required, StringLength(255), Display(Name = "Event Location")]
        public string EventLocation { get; set; }

        [Required, StringLength(255), Display(Name = "Event Date")]
        public string EventDate { get; set; }

        [Required, StringLength(255), Display(Name = "Event Time")]
        public string EventTime { get; set; }





    }
}
