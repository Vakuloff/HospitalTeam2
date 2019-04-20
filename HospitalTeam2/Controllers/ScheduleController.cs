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
    public class ScheduleController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public ScheduleController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(db.Schedules.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL STAFF
            List<Schedule> schedules = db.Schedules.Include(sc => sc.Staff).ToList();


            return View(schedules);
        }
        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Schedules.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from schedules where scheduleid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Schedule scheduletoshow = db.Schedules.Include(sc => sc.Staff).SingleOrDefault(s => s.ScheduleId == id); ;
            return View(scheduletoshow);
        }
        public ActionResult Create()
        {
            ScheduleEdit se = new ScheduleEdit();
            se.Staffs = db.Staffs.ToList();
            return View(se);
        }
        [HttpPost]
        public ActionResult Create(DateTime Date, DateTime StartShift, DateTime EndShift, int StaffId)
        {
            //Query   
            string query = "insert into schedules ( Date, StartShift, EndShift, StaffId) values (@d, @st, @et, @sid)";

            SqlParameter[] myparams = new SqlParameter[4];


            myparams[0] = new SqlParameter("@d", Date);

            myparams[1] = new SqlParameter("@st", StartShift);

            myparams[2] = new SqlParameter("@et", EndShift);

            myparams[3] = new SqlParameter("@sid", StaffId);



            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {

            ScheduleEdit scheduleeditview = new ScheduleEdit();

            //Finds all staffs
            scheduleeditview.Staffs = db.Staffs.ToList();

            //finds all schedules
            scheduleeditview.Schedules = db.Schedules.Include(sc => sc.Staff).SingleOrDefault(s => s.ScheduleId == id);
            //GOTO: Views/Staff/Edit.cshtml
            return View(scheduleeditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, DateTime Date_New, DateTime StartShift_New, DateTime EndShift_New, int StaffId)
        {

            if ((id == null) || (db.Schedules.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query

            string query = "update schedules set Date=@d, StartShift=@sh, EndShift=@se,  StaffId=@sid where ScheduleId=@id";


            SqlParameter[] myparams = new SqlParameter[5];

            myparams[0] = new SqlParameter("@d", Date_New);

            myparams[1] = new SqlParameter("@sh", StartShift_New);

            myparams[2] = new SqlParameter("@se", EndShift_New);

            myparams[3] = new SqlParameter("@sid", StaffId);

            myparams[4] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            //return RedirectToAction("List");
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Schedule schedule = db.Schedules.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return View(schedule);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Schedule schedule = db.Schedules.Find(id);
            db.Schedules.Remove(schedule);
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