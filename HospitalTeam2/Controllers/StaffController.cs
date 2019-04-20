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
using System.Data;
using System.Diagnostics;

namespace HospitalTeam2.Controllers
{
    public class StaffController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public StaffController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }


        // GET: Staff
        public IActionResult Index()
        {

            return View(db.Staffs.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL STAFF
            List<Staff> staffs = db.Staffs.Include(s => s.Department).Include(s => s.hospital).ToList();


            return View(staffs);
        }
        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Staffs.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from staffs where staffid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Staff staffstoshow = db.Staffs.Include(s => s.Department).Include(s => s.hospital).SingleOrDefault(h => h.StaffId == id);
            return View(staffstoshow);
        }

        public ActionResult Create()
        {
            StaffEdit se = new StaffEdit();
            se.Departments = db.Departments.ToList();
            se.Hospitals = db.Hospitals.ToList();
            return View(se);
        }



        [HttpPost]
        public ActionResult Create(string StaffFirstName, string StaffLastName, string TypeDoctor, int DepartmentID,  int HospitalId)
        {
            //Query   
            string query = "insert into staffs ( StaffFirstName, StaffLastName, TypeDoctor, DepartmentID,  HospitalId) values (@sfn, @sln, @td, @depid,  @hid)";

            SqlParameter[] myparams = new SqlParameter[5];

            //myparams[0] = new SqlParameter("@sid", StaffId);

            myparams[0] = new SqlParameter("@sfn", StaffFirstName);

            myparams[1] = new SqlParameter("@sln", StaffLastName);

            myparams[2] = new SqlParameter("@td", TypeDoctor);

            myparams[3] = new SqlParameter("@depid", DepartmentID);

            myparams[4] = new SqlParameter("@hid", HospitalId);


            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {

            StaffEdit staffeditview = new StaffEdit();

            //Finds all hospitals
            staffeditview.Hospitals = db.Hospitals.ToList();
            //Finds all departments
            staffeditview.Departments = db.Departments.ToList();
            //finds all staff
            staffeditview.Staffs = db.Staffs.Include(s => s.hospital).Include(s => s.Department).SingleOrDefault(h => h.StaffId == id);
            //GOTO: Views/Staff/Edit.cshtml
            return View(staffeditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string StaffFirstName_New, string StaffLastName_New, string TypeDoctor_New, int DepartmentID, int HospitalId)
        {

            if ((id == null) || (db.Staffs.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query

            string query = "update staffs set StaffFirstName=@sfn, StaffLastName=@sln, TypeDoctor=@td,  DepartmentId=@depid, HospitalId=@hid where StaffId=@id";


            SqlParameter[] myparams = new SqlParameter[6];

            myparams[0] = new SqlParameter("@sfn", StaffFirstName_New);

            myparams[1] = new SqlParameter("@sln", StaffLastName_New);

            myparams[2] = new SqlParameter("@td", TypeDoctor_New);

            myparams[3] = new SqlParameter("@depid", DepartmentID);

            myparams[4] = new SqlParameter("@hid", HospitalId);

            myparams[5] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }
        
        
        // GET: Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Staff staff = db.Staffs.Find(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Staff staff = db.Staffs.Find(id);
            db.Staffs.Remove(staff);
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