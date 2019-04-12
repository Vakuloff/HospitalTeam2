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

        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Hospitals.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from hospitals where hospitalid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Hospital hospshow = db.Hospitals.SingleOrDefault(h => h.HospitalID == id);

            return View(hospshow);

        }

        // GET: Hospitals/Create

        public ActionResult New()
        {

            return View();
        }

        // POST: Hospitals/Create

        [HttpPost]
        public ActionResult Create(string HospitalTitle_New,string Address_New, string Email_New, string Phone_New, string Description_New)
        {
            string query = "insert into hospitals (HospitalTitle, Address, Email, Phone, Description)" +
                " values (@htitle, @address, @email, @phone, @description)";
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter("@htitle", HospitalTitle_New);
            myparams[1] = new SqlParameter("@address", Address_New);
            myparams[2] = new SqlParameter("@email", Email_New);
            myparams[3] = new SqlParameter("@phone", Phone_New);
            myparams[4] = new SqlParameter("@description", Description_New);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
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