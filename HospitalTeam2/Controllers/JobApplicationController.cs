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
    public class JobApplicationController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public JobApplicationController(HospitalCMSContext context, IHostingEnvironment env)
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


            string query = "select * from jobapplications";

            List<JobApplication> jobapplications = db.JobApplications.Include(j => j.JobPosting).ToList();

            return View(jobapplications);

        }

        public ActionResult New()
        {
            //need to give a list of the jobposting 
            var jobapp = new JobApplicationEdit();
            jobapp.JobPostings = db.JobPostings.ToList();

            return View(jobapp);
        }

        [HttpPost]
        public ActionResult Create(int JobPostingId, string FirstName_New, string LastName_New, string Email_New, string Phone_New, string CoverLetter_New, string Resume_New)
        {
            string query = "insert into jobapplications (JobPostingId,FirstName, LastName, Email, Phone, CoverLetter, Resume)" +
                " values (@jId, @fname, @lname, @email, @phone, @coverletter, @resume)";
            SqlParameter[] myparams = new SqlParameter[7];
            myparams[0] = new SqlParameter("@jid", JobPostingId);
            myparams[1] = new SqlParameter("@fname", FirstName_New);
            myparams[2] = new SqlParameter("@lname", LastName_New);
            myparams[3] = new SqlParameter("@email", Email_New);
            myparams[4] = new SqlParameter("@phone", Phone_New);
            myparams[5] = new SqlParameter("@coverletter", CoverLetter_New);
            myparams[6] = new SqlParameter("@resume", Resume_New);


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }
        //we decided that admin can't edit jobapplication



        // GET: JobApplication/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            JobApplication JobApplication = db.JobApplications.Find(id);
            if (JobApplication == null)
            {
                return NotFound();
            }
            return View(JobApplication);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            JobApplication Jobapplication = db.JobApplications.Find(id);
            db.JobApplications.Remove(Jobapplication);
            db.SaveChanges();
            return RedirectToAction("List");
        }




        public ActionResult Show(int? id)
        {
            //this is for squidward (admin) to review spongebob's job application to be a doctor
            if ((id == null) || (db.JobApplications.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from jobapplications where jobapplicationid=@id";
            SqlParameter param = new SqlParameter("@id", id);


            //[db.JobApplications.Where(ja=>ja.JobApplicationID==id)] => just to get the jobapplication itself (spongebobs application)
            //[.Include(ja=>ja.JobPositionID)] => this is the jobposition (spongebob applying to be a doctor)
            //select * from jobapplications 
            //left join jobs on jobs.jobid = jobapplications.jobid
            //where jobapplicationod=id
            var jobapp = db.JobApplications.Where(ja => ja.JobApplicationID == id).Include(ja => ja.JobPostingID);

            return View(jobapp);

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