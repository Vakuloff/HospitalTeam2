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
    public class ContactFormController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public ContactFormController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(db.ContactForms.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL STAFF
            List<ContactForm> contactforms = db.ContactForms.Include(cf => cf.Hospital).ToList();


            return View(contactforms);
        }
        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.ContactForms.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from contactForms where contactid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            ContactForm contactformtoshow = db.ContactForms.Include(cf => cf.Hospital).SingleOrDefault(h => h.HospitalID == id); ;
            return View(contactformtoshow);
        }
        public ActionResult Create()
        {
            ContactFormEdit cfe = new ContactFormEdit();
            cfe.Hospitals = db.Hospitals.ToList();
            return View(cfe);
        }
        [HttpPost]
        public ActionResult Create(string FullName, string PhoneNumber,string Email,string Topic, string Message, string MessageStatus, string AdminReply, int HospitalID)
        {
            //Query   
            string query = "insert into contactforms ( FullName, PhoneNumber, Email, Topic, Message, MessageStatus, AdminReply, HospitalID) values (@fn, @pn, @e, @t, @m, @ms, @ar, @hid)";

            SqlParameter[] myparams = new SqlParameter[8];

            myparams[0] = new SqlParameter("@fn", FullName);

            myparams[1] = new SqlParameter("@pn", PhoneNumber);

            myparams[2] = new SqlParameter("@e", Email);

            myparams[3] = new SqlParameter("@t", Topic);

            myparams[4] = new SqlParameter("@m", Message);

            myparams[5] = new SqlParameter("@ms", MessageStatus);

            myparams[6] = new SqlParameter("@ar", AdminReply);

            myparams[7] = new SqlParameter("@hid", HospitalID);



            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {

            ContactFormEdit contactformeditview = new ContactFormEdit();

            //Finds all staffs
            contactformeditview.Hospitals = db.Hospitals.ToList();

            //finds all schedules
            contactformeditview.ContactForms = db.ContactForms.Include(cf => cf.Hospital).SingleOrDefault(h => h.ContactId == id);
            //GOTO: Views/Staff/Edit.cshtml
            return View(contactformeditview);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string MessageId, string FullName_New, string PhoneNumber_New, string Email_New, string Topic_New, string Message_New, string MessageStatus_New, string AdminReply_New, int HospitalID)
        {

            if ((id == null) || (db.ContactForms.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query

            string query = "update contactforms set Fullname=@fn, PhoneNumber=@pn, Email=@e,  Topic=@t, Message=@m, MessageStatus=@ms, AdminReply=@ar, HospitalId=@hid where ContactId=@id";


            SqlParameter[] myparams = new SqlParameter[9];

            myparams[0] = new SqlParameter("@fn", FullName_New);

            myparams[1] = new SqlParameter("@pn", PhoneNumber_New);

            myparams[2] = new SqlParameter("@e", Email_New);

            myparams[3] = new SqlParameter("@t", Topic_New);

            myparams[4] = new SqlParameter("@m", Message_New);

            myparams[5] = new SqlParameter("@ms", MessageStatus_New);

            myparams[6] = new SqlParameter("@ar", AdminReply_New);

            myparams[7] = new SqlParameter("@hid", HospitalID);

            myparams[8] = new SqlParameter("@id", id);

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
            ContactForm contactform = db.ContactForms.Find(id);
            if (contactform == null)
            {
                return NotFound();
            }
            return View(contactform);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            ContactForm contactform = db.ContactForms.Find(id);
            db.ContactForms.Remove(contactform);
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