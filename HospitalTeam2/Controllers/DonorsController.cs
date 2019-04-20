using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HospitalTeam2.Models;
using HospitalTeam2.Models.ViewModels;
using HospitalTeam2.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HospitalTeam2.Controllers
{
    public class DonorsController : Controller
    {
        private readonly HospitalCMSContext _context;
        
        private readonly IHostingEnvironment _env;

        public DonorsController(HospitalCMSContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Donors with pagination 
        public async Task<IActionResult> Index(int pagenum)
        {
            var _donors = await _context.Donors.ToListAsync();
            //get total donors in the db
            int donorcount = _donors.Count();
            //set number of donors on page
            int perpage = 3;
            //find number of pages
            int maxpage = (int)Math.Ceiling((decimal)donorcount / perpage) - 1;
            if (maxpage < 0) maxpage = 0;
            if (pagenum < 0) pagenum = 0;
            if (pagenum > maxpage) pagenum = maxpage;
            int start = perpage * pagenum;
            ViewData["pagenum"] = (int)pagenum;
            ViewData["PaginationSummary"] = "";
            if (maxpage > 0)
            {
                ViewData["PaginationSummary"] =
                    (pagenum + 1).ToString() + " of " +
                    (maxpage + 1).ToString();
            }
            return View(await _context.Donors.Skip(start).Take(perpage).ToListAsync());
        }

        // GET: Donors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .SingleOrDefaultAsync(m => m.DonorID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        public IActionResult Create()
        {
            return View();
        }


        // POST: Donors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonorID,DonorName,DonorMessage,ImageUrl")] Donor donor)
        {
                                   


            if (ModelState.IsValid)
            {
                                   
             _context.Add(donor);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
             }
            return View(donor);
        }

        // GET: Donors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors.SingleOrDefaultAsync(m => m.DonorID == id);
            if (donor == null)
            {
                return NotFound();
            }
            return View(donor);
        }

        // POST: Donors/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonorID,DonorName,DonorMessage")] Donor donor, IFormFile imageUrl)
        {
            //Taken from christines example
            donor.HasPic = 0;
            var webRoot = _env.WebRootPath;
            if (imageUrl != null)
            {
                if (imageUrl.Length > 0)
                {
                    
                    var valtypes = new[] { "jpeg", "jpg", "png", "gif" };
                    var extension = Path.GetExtension(imageUrl.FileName).Substring(1);

                    if (valtypes.Contains(extension))
                    {

                        //generic .img extension, web translates easily.
                        string fn = donor.DonorID + "." + extension;

                        //get a direct file path to imgs/authors/
                        string path = Path.Combine(webRoot, "images/donors");
                        path = Path.Combine(path, fn);

                        //save the file
                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            imageUrl.CopyTo(stream);
                        }
                        //let the model know that there is a picture with an extension
                        donor.HasPic = 1;
                        donor.ImageUrl = extension;

                    }
                }
            }
            if (id != donor.DonorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonorExists(donor.DonorID))
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
            return View(donor);
        }

        // GET: Donors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donor = await _context.Donors
                .SingleOrDefaultAsync(m => m.DonorID == id);
            if (donor == null)
            {
                return NotFound();
            }

            return View(donor);
        }

        // POST: Donors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donor = await _context.Donors.SingleOrDefaultAsync(m => m.DonorID == id);
            _context.Donors.Remove(donor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonorExists(int id)
        {
            return _context.Donors.Any(e => e.DonorID == id);
        }
    }
}
