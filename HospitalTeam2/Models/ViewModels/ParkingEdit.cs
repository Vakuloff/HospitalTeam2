using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2.Models.ViewModels
{
    public class ParkingEdit
    {
        public IEnumerable<Hospital> Hospitals { get; set; }

        public virtual Parking parking { get; set; }

    }
}
