using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalTeam2.Data;
using HospitalTeam2.Models;
using System.Data.SqlClient;
using HospitalTeam2.Models.ViewModels;

namespace HospitalTeam2.Controllers
{
    public class ParkingsController : Controller
    {
        private readonly HospitalCMSContext _context;

        public ParkingsController(HospitalCMSContext context)
        {
            _context = context;
        }

        // GET: Parkings
        public IActionResult Index()
        {
            IList<Parking> parkings = _context.Parkings.Include(p => p.hospital).ToList();
            //var hospitalCMSContext = _context.Parkings.Include(p => p.hospital);
            return View(parkings);
        }

        // GET: Parkings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .Include(p => p.hospital)
                .SingleOrDefaultAsync(m => m.ParkingID == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // GET: Parkings/Create
        public IActionResult Create()
        {
            var parkedit = new ParkingEdit();
            parkedit.Hospitals = _context.Hospitals.ToList();
            return View(parkedit);
        }

        // POST: Parkings/Create
        
        [HttpPost]
        
        public ActionResult Create(string ParkingName_New, string ParkingCar_New, string ParkingPurpose_New, string ParkingContact_New, int ParkHospital_New)
        {
            string query = "insert into parkings (VisitorName, VisitoCarNo, ParkingPurpose, ParkingContact, HospitalID) values (@name, @car, @ppurpose, @contact, @hospital)";
            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@name", ParkingName_New);
            myparams[1] = new SqlParameter("@car", ParkingCar_New);
            myparams[2] = new SqlParameter("@ppurpose", ParkingPurpose_New);
            myparams[3] = new SqlParameter("@contact", ParkingContact_New);
            myparams[4] = new SqlParameter("@hospital", ParkHospital_New);

            _context.Database.ExecuteSqlCommand(query, myparams);

            
            //ViewData["HospitalID"] = new SelectList(_context.Hospitals, "HospitalID", "Address", parking.hospital);
            return RedirectToAction("Index");
        }

        // GET: Parkings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.ParkingID == id);
            if (parking == null)
            {
                return NotFound();
            }
            ViewData["HospitalID"] = new SelectList(_context.Hospitals, "HospitalID", "HospitalTitle", parking.hospital);
            return View(parking);
        }

        // POST: Parkings/Edit/5
        
        [HttpPost]
        
        public ActionResult Edit(int id, string VisitorName, string VisitoCarNo, string ParkingPurpose, string ParkingContact, int ParkingHospital)
        {
            if (_context.Parkings.Find(id) == null) 
            {
                return NotFound();
            }
            string query = "update parkings set VisitorName=@name, VisitoCarNo=@car, ParkingPurpose=@ppurpose, ParkingContact=@contact, HospitalID=@hospital where ParkingID=@id";
            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@name", VisitorName);
            myparams[1] = new SqlParameter("@car", VisitoCarNo);
            myparams[2] = new SqlParameter("@ppurpose", ParkingPurpose);
            myparams[3] = new SqlParameter("@contact", ParkingContact);
            myparams[4] = new SqlParameter("@hospital", ParkingHospital);
            myparams[4] = new SqlParameter("@id", id);
            _context.Database.ExecuteSqlCommand(query, myparams);



            return RedirectToAction("Index");
        }

        // GET: Parkings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parking = await _context.Parkings
                .Include(p => p.hospital)
                .SingleOrDefaultAsync(m => m.ParkingID == id);
            if (parking == null)
            {
                return NotFound();
            }

            return View(parking);
        }

        // POST: Parkings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parking = await _context.Parkings.SingleOrDefaultAsync(m => m.ParkingID == id);
            _context.Parkings.Remove(parking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingExists(int id)
        {
            return _context.Parkings.Any(e => e.ParkingID == id);
        }
    }
}
