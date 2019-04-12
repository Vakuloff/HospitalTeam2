using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalTeam2.Data;
using HospitalTeam2.Models;

namespace HospitalNew.Controllers
{
    public class MenusController : Controller
    {
        private readonly HospitalCMSContext _context;

        public MenusController(HospitalCMSContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Navigation()
        {
            return PartialView(await _context.NavMenus.ToListAsync());
        }

        // GET: NavMenu
        public async Task<IActionResult> Index()
        {
            return View(await _context.NavMenus.ToListAsync());
        }

        // GET: NavMenu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMenus = await _context.NavMenus.ToListAsync();
            var navMenu = allMenus.FirstOrDefault(menu => menu.Id == id);
            if (navMenu == null)
            {
                return NotFound();
            }

            return View(navMenu);
        }

        // GET: NavMenu/Create
        public IActionResult Create()
        {
            var parentMenus = _context.NavMenus.Where(m => !m.NavMenuItemId.HasValue).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.Title });
            ViewBag.ParentItems = parentMenus;
            return View();
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Url,NavMenuItemId,IsShown")] NavMenu navMenu)
        {
            if (ModelState.IsValid)
            {
                navMenu.NavMenuItemId = navMenu.NavMenuItemId == 0 ? null : navMenu.NavMenuItemId;
                _context.Add(navMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(navMenu);
        }

        // GET: NavMenu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMenus = await _context.NavMenus.ToListAsync();
            var navMenu = allMenus.FirstOrDefault(menu => menu.Id == id);
            if (navMenu == null)
            {
                return NotFound();
            }
            var parentMenus = _context.NavMenus.Where(m => !m.NavMenuItemId.HasValue).ToList().Select(rr => new SelectListItem { Value = rr.Id.ToString(), Text = rr.Title });
            ViewBag.ParentItems = parentMenus;
            return View(navMenu);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Url,NavMenuItemId,IsShown")] NavMenu navMenu)
        {
            if (id != navMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    navMenu.NavMenuItemId = navMenu.NavMenuItemId == 0 ? null : navMenu.NavMenuItemId;
                    _context.Update(navMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavMenuExists(navMenu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(navMenu);
        }

        // GET: NavMenu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var allMenus = await _context.NavMenus.ToListAsync();
            var navMenu = allMenus.FirstOrDefault(menu => menu.Id == id);
            if (navMenu == null)
            {
                return NotFound();
            }

            return View(navMenu);
        }

        // POST: NavMenu/Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var allMenus = await _context.NavMenus.ToListAsync();
            var navMenu = allMenus.FirstOrDefault(menu => menu.Id == id);

            if(navMenu.ChildMenuItems!=null)
            {
                foreach (var childItem in navMenu.ChildMenuItems)
                {
                    _context.NavMenus.Remove(childItem);
                }
            }
           
            _context.NavMenus.Remove(navMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavMenuExists(int id)
        {
            return _context.NavMenus.Any(e => e.Id == id);
        }
    }
}
