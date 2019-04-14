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
            //need to give a list of the hospitals so that they can select the one they want
            var deptedit = new DepartmentEdit();
            deptedit.Hospitals = db.Hospitals.ToList();

            return View(deptedit);
        }

        [HttpPost]
        public ActionResult Create(string DepartmentTitle_New, int hospitalid)
        {

            //the db is asking for the hospitaltitle and jobposting title,
            //neither of which should exist correct way is to fix db migrations with all laptops there
            //however, we sate this by adding dummy info into hospitaltitle and jobpostingtitle
            string query = "insert into departments ( DepartmentTitle, HospitalID)" +
                " values ( @dtitle, @hid)";
          
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@dtitle", DepartmentTitle_New);
            myparams[1] = new SqlParameter("@hid", hospitalid);
         


            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {


            DepartmentEdit depeditview = new DepartmentEdit();

            depeditview.Hospitals = db.Hospitals.ToList();
            depeditview.Departments = db.Departments.Include(h => h.Hospital).SingleOrDefault(d => d.DepartmentID == id); //finds all department

            //GOTO: Views/Job/Edit.cshtml
            return View(depeditview);
        }




        [HttpPost]
        public ActionResult Edit(int? id, int HospitalID, string DepartmentTitle)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();
            }
            string query = "update departments set HospitalID=@hid, DepartmentTitle=@dtitle" +
                " where departmentid=@id";
            SqlParameter[] myparams = new SqlParameter[2];

            myparams[0] = new SqlParameter("@hid",HospitalID);
            myparams[1] = new SqlParameter("@dtitle", DepartmentTitle);
            myparams[2] = new SqlParameter("@id", id);

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

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("List");
        }



        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Departments.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from departments where departmentid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Department departmentshow = db.Departments.Include(h => h.Hospital).SingleOrDefault(d => d.DepartmentID == id);
            return View(departmentshow);

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