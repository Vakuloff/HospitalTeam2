using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospitalTeam2.Models
{
    public class FAQ
    {
        [Key]
        public int FaqID { get; set; }

        [Required, StringLength(255), Display(Name = "Question")]
        public string FaqQues { get; set; }

        [Required, StringLength(255), Display(Name = "Answer")]
        public string FaqAns { get; set; }
    }
}
