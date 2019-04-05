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
    public class DepartmentController : Controller
    {
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public DepartmentController(HospitalCMSContext context, IHostingEnvironment env)
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


            string query = "select * from departments";

            List<Department> departments = db.Departments.Include(h => h.Hospital).ToList();

            return View(departments);

        }


        public ActionResult New()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(string DepartmentTitle_New, string HospitalTitle_New, string JobPosting_New)
        {
            string query = "insert into departments ( DepartmentTitle, HospitalTitle,JobPosting)" +
                " values ( @dtitle,@htitle, @jposting)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@dtitle", DepartmentTitle_New);
            myparams[1] = new SqlParameter("@htitle", HospitalTitle_New);
            myparams[2] = new SqlParameter("@jposting", JobPosting_New);
           


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();
            }
            string query = "select * from departments where departmentid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Department mydep = db.Departments.FromSql(query, param).FirstOrDefault();
            return View(mydep);
        }

        


        [HttpPost]
        public ActionResult Edit(int? id, string DepartmentTitle, string HospitalTitle, string JobPosting)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update departments set DepartmentTitle=@dtitle, HospitalTitle=@htitle, JobPosting=@jposting" +
                " where departmentid=@id";
            SqlParameter[] myparams = new SqlParameter[3];

            myparams[0] = new SqlParameter("@dtitle",DepartmentTitle);
            myparams[1] = new SqlParameter("@htitle", HospitalTitle);
            myparams[2] = new SqlParameter("@jposting", JobPosting); 
            myparams[3] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();

            }
            string query = "delete from departments where departmentid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);
            return View("List");
        }


       /* public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from departments where departmentid=@id";
            SqlParameter param = new SqlParameter("@id", id);

             departmentshow = db.Departments.Include(h => h.Hospital).Include(j => j.JobPostings).SingleOrDefault(d => d.DepartmentID == id);

            return View(departmentshow);

        }*/

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