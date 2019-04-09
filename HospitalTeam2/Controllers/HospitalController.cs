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
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace HospitalTeam2.Controllers
{
    public class HospitalController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public HospitalController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }



        // GET: Hospitals
        public ActionResult Index()
        {

            return View(db.Hospitals.ToList());
        }

        public ActionResult List()
        {


            string query = "select * from hospitals";

            IEnumerable<Hospital> hospitals = db.Hospitals.FromSql(query);

            return View(hospitals);

        }


        public ActionResult Show(int id)
        {
            //wrapper
            return RedirectToAction("Details/" + id);
        }


        // GET: Hospitals/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Hospitals/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("HospitalID,HospitalTitle,Address,Email,Phone,Description")] Hospital hospital)
        {

            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(hospital);
        }






        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        { 

            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}