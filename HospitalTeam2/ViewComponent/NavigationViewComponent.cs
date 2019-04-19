using HospitalTeam2.Data;
using HospitalTeam2.Models;
using Microsoft.AspNetCore.Identity;
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

        private readonly SignInManager<ApplicationUser> _signInManager;

        public NavigationViewComponent(SignInManager<ApplicationUser> signInManager, HospitalCMSContext context)
        {
            _context = context;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if(_signInManager.IsSignedIn(UserClaimsPrincipal))
            {
                var navMenus = await _context.NavMenus.ToListAsync();
                return View("Menu", navMenus);
            }
            else
            {
                return View("Menu");
            }
           
        }
    }
}
