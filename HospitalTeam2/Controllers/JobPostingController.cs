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

namespace HospitalTeam2.Controllers
{
    public class JobPostingController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public SqlDbType JobPostingTitle { get; private set; }

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

        public ActionResult Show(int id)
        {
            //wrapper
            return RedirectToAction("Details/" + id);
        }

        public ActionResult List()
        {
            //LIST WILL SHOW ALL JOB POSITIONS
            //WHAT INFORMATION DO I NEED
            List<JobPosting> jobposting = db.JobPostings.Include(h => h.Hospital).Include(d => d.Department).ToList();

            //GOTO Views/jobposition/List.cshtml
            return View(jobposting);
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
        public ActionResult Create(int HospitalId, int DepartmentId, string JobPostingTitle_New,  string JobPostingType_New, string JobPostingDesc_New, string JobPostingReq_New)
        {


            //Query   
            string query = "insert into jobpostings (HospitalId, DepartmentId, JobPostingTitle, JobPostingType, JobPostingDesc, JobPostingReq) values (@hid, @did, @title, @type, @desc, @req)";


            SqlParameter[] myparams = new SqlParameter[6];
            //@hospital (id) FOREIGN KEY param
            myparams[0] = new SqlParameter("@hid", HospitalId);
            //@department (id) FOREIGN KEY param
            myparams[1] = new SqlParameter("@did", DepartmentId);
            //@title parameter
            myparams[2] = new SqlParameter("@title", JobPostingTitle_New);
            //@type paramter
            myparams[3] = new SqlParameter("@type", JobPostingType_New);
            //@desc parameter
            myparams[4] = new SqlParameter("@desc", JobPostingDesc_New);
            //@req parameter
            myparams[5] = new SqlParameter("@req", JobPostingReq_New);
           
            
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            JobPostingEdit positioneditview = new JobPostingEdit();


            positioneditview.Hospitals = db.Hospitals.ToList(); //Finds all hospitals


            positioneditview.JobPostings = db.JobPostings.Include(h => h.Hospital).SingleOrDefault(j => j.JobPostingID == id); //finds all job

            //GOTO: Views/Job/Edit.cshtml
            return View(positioneditview);
        }

        [HttpPost]
        public ActionResult Edit(int id, string HospitalTitle, string JobPostingTitle, string Department, string JobPostingType, string JobPostingDesc, string JobPostingReq)
        {

            if ((id == null) || (db.JobPostings.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query
            string query = "update jobpostings set HospitalTitle=@hid, Department = @did, JobPostingTitle=@title,  JobPostingType=@type,JobPostingDesc=@desc, JobPostingReq=@req where JobPostingID=@id";


            SqlParameter[] myparams = new SqlParameter[6];
            //Parameter for @hospital FK
            myparams[0] = new SqlParameter("@hid", HospitalTitle);
            //Parameter for (department) id FOREIGN KEY
            myparams[1] = new SqlParameter("@did", Department);
            //Parameter for @title "jobPostTitle"
            myparams[2] = new SqlParameter("@title", JobPostingTitle); 
            //Parameter for @type "jobpostingtype"
            myparams[3] = new SqlParameter("@type", JobPostingType);
            //Parameter for @desc "JobDesc"
            myparams[4] = new SqlParameter("@desc", JobPostingDesc);
            //Parameter for @req "JobReq"
            myparams[5] = new SqlParameter("@req", JobPostingReq);
            
            //Pararameter for (Position) id PRIMARY KEY
            myparams[6] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: View/Blog/Show.cshtml with paramter Blogid passed
            return RedirectToAction("Show/" + id);
        }
        public ActionResult Show(int? id)
        {

            if ((id == null) || (db.JobPostings.Find(id) == null))
            {
                return NotFound();

            }
            //Raw MSSQL query
            string query = "select * from jobpostings where jobpostingid=@id";


            SqlParameter myparam = new SqlParameter("@id", id);


            JobPosting myjob = db.JobPostings.Include(h => h.Hospital).Include(d =>d.Department).SingleOrDefault(b => b.JobPostingID == id);

            return View(myjob);

        }

        public ActionResult Delete(int? id)
        {

            if ((id == null) || (db.JobPostings.Find(id) == null))
            {
                return NotFound();

            }

            string query = "delete from hospitals where JobPostingID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from departments where JobPostingID=@id";
            param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            query = "delete from jobposting where jobpostingid=@id";
            param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
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

