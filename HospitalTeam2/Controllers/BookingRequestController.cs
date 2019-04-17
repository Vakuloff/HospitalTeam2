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

            return View(db.BookingRequests.ToList());
        }

        public ActionResult List()
        {
          

            string query = "select * from bookingrequests";

            List<BookingRequest> bookingRequests = db.BookingRequests.Include(br => br.Hospital).ThenInclude(b => b.Staffs).ToList();

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
            string query = "insert into bookingrequests (HospitalID, StaffId, Reason, Date, Time, FirstName, LastName, Email, Phone, Age)" +
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

            bookeditview.BookingRequests = db.BookingRequests.Include(br => br.Hospital).Include(b => b.Staff).SingleOrDefault(s => s.BookingID == id); //finds all booking

            //GOTO: Views/Job/Edit.cshtml
            return View(bookeditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string HospitalTitle,string StaffFirstName, string StaffLastName, string TypeDoctor, string Reason, string Date, string Time, string FirstName, string LastName, string Email, string Phone, string Age)
        {
            if ((id == null) || (db.BookingRequests.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update bookingrequests set HospitalTitle=@htitle, StaffFirstName=@sfname, StaffLastname=@slname, TypeDoctor=@tdoc, Reason=@reason, Date=@date, Time=@time, FirstName@fname, LastName=@lname, Email=@email, Phone=@phone, Age=@age"
                + " where bookingid=@id";
            SqlParameter[] myparams = new SqlParameter[13];

            myparams[0] = new SqlParameter("@htitle", HospitalTitle);
            myparams[1] = new SqlParameter("@sfname", StaffFirstName);
            myparams[2] = new SqlParameter("@slname", StaffLastName);
            myparams[3] = new SqlParameter("@tdoc", TypeDoctor);
            myparams[4] = new SqlParameter("@reson", Reason);
            myparams[5] = new SqlParameter("@date", Date);
            myparams[6] = new SqlParameter("@time", Time);
            myparams[7] = new SqlParameter("@fname", FirstName);
            myparams[8] = new SqlParameter("@lname", LastName);
            myparams[9] = new SqlParameter("@email", Email);
            myparams[10] = new SqlParameter("@phone", Phone);
            myparams[11] = new SqlParameter("@age", Age);
            myparams[12] = new SqlParameter("@id", id);

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
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            if (bookingRequest == null)
            {
                return NotFound();
            }
            return View(bookingRequest);
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

            BookingRequest bookingshow = db.BookingRequests.Include(br => br.Hospital).Include(b => b.Staff).SingleOrDefault(h => h.BookingID == id);

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