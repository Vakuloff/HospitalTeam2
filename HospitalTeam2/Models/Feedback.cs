using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalNew.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbacksId { get; set; }

        [Required, StringLength(255), Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required, StringLength(255), Display(Name = "Feedbacks Email")]
        public string FeedbacksEmail { get; set; }

        [Required, StringLength(255), Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        [Required, StringLength(255), Display(Name = "Feedbacks Subject")]
        public string FeedbacksSubject { get; set; }

        [Required, StringLength(255), Display(Name = "Feedbacks Message")]
        public string FeedbacksMessage { get; set; }

    }
}
