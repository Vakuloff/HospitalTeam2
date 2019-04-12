using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Required, StringLength(255), Display(Name = "Blog Title")]
        public string BlogTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Blog Description")]
        public string BlogDescription { get; set; }

        [Required, StringLength(255), Display(Name = "Blog Author")]
        public string BlogAuthor { get; set; }

        [Required, StringLength(255), Display(Name = "Blog Date")]
        public string BlogDate { get; set; }

        [Required, StringLength(255), Display(Name = "Blog Time")]
        public string BlogTime { get; set; }
    }
}

