using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalTeam2.Models
{
    public class NavMenu
    {       
        [Key, ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(500), Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "Parent Menu"),ForeignKey("ParentNavMenu")]
        public int? NavMenuItemId { get; set; }
        
        [Display(Name = "Show in Navigation")]
        public bool IsShown { get; set; }
      
        public virtual List<NavMenu> ChildMenuItems { get; set; }

        public virtual NavMenu NavMenuItem { get; set; }
    }
}
