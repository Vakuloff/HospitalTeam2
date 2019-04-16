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
    public class JobPostingController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public SqlDbType StaffFirstName { get; private set; }

        public JobPostingController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }


        // GET: 
        public ActionResult Index()
        {

            return View(db.JobPostings.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL JOB POSITIONS
            //WHAT INFORMATION DO I NEED

            //JobPosting testposting = new JobPosting();
            
            List<JobPosting> jobposting = db.JobPostings.Include(jp=>jp.Hospital).Include(jp=>jp.Department).ToList();

            //GOTO Views/jobposition/List.cshtml
            return View(jobposting);
        }

        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.JobPostings.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from jobposting where jobpostingid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            JobPosting jobpostshow = db.JobPostings.Include(jp => jp.Hospital).ThenInclude(jp =>jp.Departments).SingleOrDefault(h => h.JobPostingID == id);

            return View(jobpostshow);

        }


        public ActionResult New()
        {
            //THE INFORMATION REQUIRED TO PRESENT THIS PAGE IS AS FOLLOWS\\
            //THE LIST OF HOSPITALS IN THE DATABASE
            //THE LIST OF DEPARTMENTS IN THE DATABASE

            var jobpostingedit = new JobPostingEdit();
            jobpostingedit.Departments = db.Departments.ToList();
            jobpostingedit.Hospitals = db.Hospitals.ToList();
            
            return View(jobpostingedit);
        }



        [HttpPost]
        public ActionResult Create (int HospitalID, int DepartmentID, string JobPostingTitle_New,  string JobPostingType_New, string JobPostingDesc_New, string JobPostingReq_New)
        {


            //Query   
            string query = "insert into jobpostings (HospitalID, DepartmentID, JobPostingTitle, JobPostingType, JobPostingDesc, JobPostingReq, DepartmentTitle, HospitalTitle) values (@hid, @did, @title, @type, @desc, @req, @d1, @d2)";
            //DUMMY DATA FOR DEPARTMENTITLE AND HOSPITAL TITLE BECAUSE WE DON'T NEED THAT BUT IT'S FROM THE PREVIOUS DATABASE
            //CORRECT WAY IS TO REMOVE THESE COLUMNS ENTIRE FROM THE DB

            SqlParameter[] myparams = new SqlParameter[8];
            //@hospital (id) FOREIGN KEY param
            myparams[0] = new SqlParameter("@hid", HospitalID);
            //@department (id) FOREIGN KEY param
            myparams[1] = new SqlParameter("@did", DepartmentID);
            //@title parameter
            myparams[2] = new SqlParameter("@title", JobPostingTitle_New);
            //@type paramter
            myparams[3] = new SqlParameter("@type", JobPostingType_New);
            //@desc parameter
            myparams[4] = new SqlParameter("@desc", JobPostingDesc_New);
            //@req parameter
            myparams[5] = new SqlParameter("@req", JobPostingReq_New);

            var dummytext = "";

            myparams[6] = new SqlParameter("@d1", dummytext);
            myparams[7] = new SqlParameter("@d2", dummytext);
            
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            JobPostingEdit positioneditview = new JobPostingEdit();


          positioneditview.Hospitals = db.Hospitals.ToList();
          positioneditview.Departments = db.Departments.ToList();//find all departments

            positioneditview.JobPostings = db.JobPostings.Include(jp => jp.Hospital).Include(jp => jp.Department).SingleOrDefault(h => h.JobPostingID == id); //finds all job

            //GOTO: Views/Job/Edit.cshtml
            return View(positioneditview);
        }

        [HttpPost]
        public ActionResult Edit(int? id, string JobPostingTitle, string JobPostingType, string JobPostingDesc, string JobPostingReq, string HospitalTitle, string DepartmentTitle)
        {
            Debug.WriteLine("Fk department ");

            if ((id == null) || (db.JobPostings.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query
            string query = "update jobpostings set  JobPostingTitle=@title,  JobPostingType=@type,JobPostingDesc=@desc, JobPostingReq=@req, HospitalTitle=@htitle, DepartmentTitle=@dtitle where JobPostingID=@id";


            SqlParameter[] myparams = new SqlParameter[7];
            //Parameter for @title "jobPostTitle"
            myparams[0] = new SqlParameter("@title", JobPostingTitle); 
            //Parameter for @type "jobpostingtype"
            myparams[1] = new SqlParameter("@type", JobPostingType);
            //Parameter for @desc "JobDesc"
            myparams[2] = new SqlParameter("@desc", JobPostingDesc);
            //Parameter for @req "JobReq"
            myparams[3] = new SqlParameter("@req", JobPostingReq);

            myparams[4] = new SqlParameter("@htitle", HospitalTitle);
            myparams[5] = new SqlParameter("@dtitle", DepartmentTitle);

            //Pararameter for (Position) id PRIMARY KEY
            myparams[6] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: View/Blog/Show.cshtml with paramter Blogid passed
            return RedirectToAction("Show/" + id);
        }
        // GET: JobPosting/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            JobPosting jobposting = db.JobPostings.Find(id);
            if (jobposting == null)
            {
                return NotFound();
            }
            return View(jobposting);
        }

        // POST: JobPosting/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            JobPosting jobposting = db.JobPostings.Find(id);
            db.JobPostings.Remove(jobposting);
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

