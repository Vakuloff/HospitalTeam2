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
    public class VolunteerController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public VolunteerController(HospitalCMSContext context, IHostingEnvironment env)
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


            string query = "select * from volunteers";

            List<Volunteer> volunteers = db.Volunteers.Include(v => v.Hospital).ToList();

            return View(volunteers);

        }


        public ActionResult New()
        {
            //need to give a list of the hospitals so that they can select the one they want
            var voledit = new VolunteerEdit();
            voledit.Hospitals = db.Hospitals.ToList();

            return View(voledit);
        }

        [HttpPost]
        public ActionResult Create(int HospitalId, string FirstName_New, string LastName_New, string Middle_New, string City_New, string Province_New, string Zip_New, string Phone_New, string Email_New, string Age_New, string Gender_New, string Education_New, string Experience_New, string Availability_New, string Name_New, string Phone_em_New, string Relationship_New, string HealthCondition_New)
        {
            string query = "insert into volunteers ( HospitalId, FirstName, LastName, Middle, City, Province, Zip, Phone,Email, Age, Gender,Education, Experience, Availability, Name, Phone_em, Relationship, HealthCondition)" +
                " values ( @hid,@fname, @lname,@midname,@city, @province,@zip, @phone, @email,@age, @gender, @education, @experience, @availability, @name, @phone_em, @relationship, @healthcondition)";
            SqlParameter[] myparams = new SqlParameter[18];
            myparams[0] = new SqlParameter("@hid", HospitalId);
            myparams[1] = new SqlParameter("@fname", FirstName_New);
            myparams[2] = new SqlParameter("@lname", LastName_New);
            myparams[3] = new SqlParameter("@midname", Middle_New);
            myparams[4] = new SqlParameter("@city", City_New);
            myparams[5] = new SqlParameter("@province", Province_New);
            myparams[6] = new SqlParameter("@zip", Zip_New);
            myparams[7] = new SqlParameter("@phone", Phone_New);
            myparams[8] = new SqlParameter("@email", Email_New);
            myparams[9] = new SqlParameter("@age", Age_New);
            myparams[10] = new SqlParameter("@gender", Gender_New);
            myparams[11] = new SqlParameter("@education", Education_New);
            myparams[12] = new SqlParameter("@experience", Experience_New);
            myparams[13] = new SqlParameter("@availability", Availability_New);
            myparams[14] = new SqlParameter("@name", Name_New);
            myparams[15] = new SqlParameter("@phone_em", Phone_em_New);
            myparams[16] = new SqlParameter("@relationship", Relationship_New);
            myparams[17] = new SqlParameter("@healthcondition", HealthCondition_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }



        public ActionResult Edit(int id)
        {


            VolunteerEdit voleditview = new VolunteerEdit();

            voleditview.Hospitals = db.Hospitals.ToList();
            voleditview.Volunteer = db.Volunteers.Include(h => h.Hospital).SingleOrDefault(vl => vl.VolunteerID == id); //finds all volunteer

            //GOTO: Views/Job/Edit.cshtml
            return View(voleditview);
        }


        [HttpPost]
        public ActionResult Edit(int? id, int Hospitalid, string FirstName, string LastName, string Middle, string City, string Province, string Zip, string Phone, string Email, string Age, string Gender, string Education, string Experience, string Availability, string Name, string Phone_em, string Relationship, string HealthCondition)
        {
            if ((id == null) || (db.Volunteers.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update volunteers set HospitalId=@hid, FirstName=@fname, LastName=@lname, Middle=@mname, City=@city, Province=@province, Zip=@zip, Phone=@phone, Email=@email, Age=@age, Gender=@gender, Education=@education, Experience=@experience, Availability=@availability, Name=@name, Phone_em=@phone_em, Relationship=@relationship, HealthCondition=@healthcondition" +
                " where volunteerid=@id";
            SqlParameter[] myparams = new SqlParameter[19];

            myparams[0] = new SqlParameter("@hid", Hospitalid);
            myparams[1] = new SqlParameter("@fname", FirstName);
            myparams[2] = new SqlParameter("@fname", FirstName);
            myparams[3] = new SqlParameter("@lname", LastName);
            myparams[4] = new SqlParameter("@mname", Middle);
            myparams[5] = new SqlParameter("@city", City);
            myparams[6] = new SqlParameter("@province", Province);
            myparams[7] = new SqlParameter("@zip", Zip);
            myparams[8] = new SqlParameter("@phone", Phone);
            myparams[9] = new SqlParameter("@email", Email);
            myparams[10] = new SqlParameter("@age", Age);
            myparams[11] = new SqlParameter("@gender", Gender);
            myparams[12] = new SqlParameter("@education", Education);
            myparams[13] = new SqlParameter("@experience", Experience);
            myparams[14] = new SqlParameter("@availability", Availability);
            myparams[15] = new SqlParameter("@name", Name);
            myparams[16] = new SqlParameter("@phone_em", Phone_em);
            myparams[17] = new SqlParameter("@relationship", Relationship);
            myparams[18] = new SqlParameter("@healthcondition", HealthCondition);
            myparams[19] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }

        // GET: Volunteer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Volunteer volunteer = db.Volunteers.Find(id);
            if (volunteer == null)
            {
                return NotFound();
            }
            return View(volunteer);
        }

        // POST: Volunteer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Volunteer volunteer = db.Volunteers.Find(id);
            db.Volunteers.Remove(volunteer);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Volunteers.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from volunteers where volunteerid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            Volunteer volunshow = db.Volunteers.Include(v => v.Hospital).SingleOrDefault(vl => vl.VolunteerID == id);

            return View(volunshow);

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