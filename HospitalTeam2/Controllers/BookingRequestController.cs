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

namespace HospitalTeam2.Controllers
{
    public class BookingRequestController : Controller
    {

        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public BookingRequestController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }



        public ActionResult Index()
        {
            return RedirectToAction("List");
        }


        public ActionResult List()
        {

            string query = "select * from bookingrequests";

            List<BookingRequest> bookingRequests = db.BookingRequests.Include(h => h.Hospital).ThenInclude(s => s.Staffs).ToList();

            return View(bookingRequests);

        }

        public ActionResult New()
        {
            //need to give a list of the hospitals so that they can select the one they want
            var bookedit = new BookingRequestEdit();
            bookedit.Hospitals = db.Hospitals.ToList();
            bookedit.Staffs = db.Staffs.ToList();
            return View(bookedit);
        }

        [HttpPost]
        public ActionResult Create(int HospitalID, int StaffID, string Reason_New, string Date_New, string Time_New, string FirstName_New,
            string LastName_New, string Email_New, string Phone_New, string Age_New)
        {
            string query = "insert into bookingrequests (HospitalID, staffID, Reason, Date, Time, FirstName, LastName, Email, Phone, Age)" +
                " values (@hid, @sid, @reason, @date, @time, @fname,@lname, @email, @phone, @age)";
            SqlParameter[] myparams = new SqlParameter[10];
            myparams[0] = new SqlParameter("@hid", HospitalID);
            myparams[1] = new SqlParameter("@sid", StaffID);
            myparams[2] = new SqlParameter("@reason", Reason_New);
            myparams[3] = new SqlParameter("@date", Date_New);
            myparams[4] = new SqlParameter("@time", Time_New);
            myparams[5] = new SqlParameter("@fname", FirstName_New);
            myparams[6] = new SqlParameter("@lname", LastName_New);
            myparams[7] = new SqlParameter("@email", Email_New);
            myparams[8] = new SqlParameter("@phone", Phone_New);
            myparams[9] = new SqlParameter("@age", Age_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            BookingRequestEdit bookeditview = new BookingRequestEdit();

            bookeditview.BookingRequests = db.BookingRequests.Include(h => h.Hospital).Include(s => s.Staff).SingleOrDefault(b => b.BookingID == id); //finds all booking

            //GOTO: Views/Job/Edit.cshtml
            return View(bookeditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, int HospitalId, int StaffId,string Reason, string Date, string Time, string FirstName, string LastName, string Email, string Phone, string Age)
        {
            if ((id == null) || (db.BookingRequests.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update bookingrequests set HospitalID=@hid, StaffID=@sid, Reason=@reason, Date=@date, Time=@time, FirstName@fname, LastName=@lname, Email=@email, Phone=@phone, Age=@age"
                + " where bookingid=@id";
            SqlParameter[] myparams = new SqlParameter[10];

            myparams[0] = new SqlParameter("@hid", HospitalId);
            myparams[1] = new SqlParameter("@sid", StaffId);
            myparams[2] = new SqlParameter("@reason", Reason);
            myparams[3] = new SqlParameter("@date", Date);
            myparams[4] = new SqlParameter("@time", Time);
            myparams[5] = new SqlParameter("@fname", FirstName);
            myparams[6] = new SqlParameter("@lname", LastName);
            myparams[7] = new SqlParameter("@email", Email);
            myparams[8] = new SqlParameter("@phone", Phone);
            myparams[9] = new SqlParameter("@age", Age);
            myparams[10] = new SqlParameter("@id", id);

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
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: BookingRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            db.BookingRequests.Remove(bookingRequest);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.BookingRequests.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from bookingrequests where bookingid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            BookingRequest bookingshow = db.BookingRequests.Include(h => h.Hospital).Include(s => s.Staff).SingleOrDefault(b => b.BookingID == id);

            return View(bookingshow);

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