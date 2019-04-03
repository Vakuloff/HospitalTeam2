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

            IEnumerable<BookingRequest> BookingRequests = db.BookingRequests.FromSql(query);

            return View(BookingRequests);

        }

        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string HospitalTitle_New, string TypeDoctor_New, string StaffFirstName_New, string StaffLastName_New, string Reason_New, string Date_New, string Time_New, string FirstName_New,
            string LastName_New, string Email_New, string Phone_New, string Age_New)
        {
            string query = "insert into bookingrequests (HospitalTitle, TypeDoctor, StaffFirstName,StaffLastName, Reason, Date, Time, FirstName, LastName, Email, Phone, Age)" +
                " values (@hospitaltitle, @dtype, @doctorfname, @doctorlname,@reason, @date, @time, @fname,@lname, @email, @phone, @age)";
            SqlParameter[] myparams = new SqlParameter[11];
            myparams[0] = new SqlParameter("@hospitaltitle", HospitalTitle_New);
            myparams[1] = new SqlParameter("@dtype", TypeDoctor_New);
            myparams[2] = new SqlParameter("@doctorfname", StaffFirstName_New);
            myparams[3] = new SqlParameter("@doctorlname", StaffLastName_New);
            myparams[4] = new SqlParameter("@reason", Reason_New);
            myparams[5] = new SqlParameter("@date", Date_New);
            myparams[6] = new SqlParameter("@time", Time_New);
            myparams[7] = new SqlParameter("@fname", FirstName_New);
            myparams[8] = new SqlParameter("@lname", LastName_New);
            myparams[9] = new SqlParameter("@email", Email_New);
            myparams[10] = new SqlParameter("@phone", Phone_New);
            myparams[11] = new SqlParameter("@age", Age_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            BookingRequestEdit bookeditview = new BookingRequestEdit();

            bookeditview.BookingRequest = db.BookingRequests.Include(h => h.Hospital).Include(s => s.Staff).SingleOrDefault(b => b.BookingID == id); //finds all booking

            //GOTO: Views/Job/Edit.cshtml
            return View(bookeditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string HospitalTitle, string TypeDoctor, string StaffFirstName, string StaffLastName, string Reason, string Date, string Time, string FirstName, string LastName, string Email, string Phone, string Age)
        {
            if ((id == null) || (db.BookingRequests.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update bookingrequests set HospitalTitle=@location, TypeDoctor=@dtype, StaffFirstName=@doctorfname,StaffLastName=@doctorlname, Reason=@reason, Date=@date, Time=@time, FirstName@fname, LastName=@lname, Email=@email, Phone=@phone, Age=@age"
                + " where bookingid=@id";
            SqlParameter[] myparams = new SqlParameter[12];

            myparams[0] = new SqlParameter("@location", HospitalTitle);
            myparams[1] = new SqlParameter("@dtype", TypeDoctor);
            myparams[2] = new SqlParameter("@doctorfname", StaffFirstName);
            myparams[3] = new SqlParameter("@doctorlname", StaffLastName);
            myparams[4] = new SqlParameter("@reason", Reason);
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

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.BookingRequests.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from bookingrequests where bookingid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return View("List");
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