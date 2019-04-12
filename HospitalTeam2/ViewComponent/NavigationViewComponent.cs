using HospitalTeam2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalTeam2
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly HospitalCMSContext _context;

        public NavigationViewComponent(HospitalCMSContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navMenus = await _context.NavMenus.ToListAsync();
            return View("Menu", navMenus);
        }
    }
}
