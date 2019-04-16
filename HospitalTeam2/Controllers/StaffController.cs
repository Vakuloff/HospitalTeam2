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
    public class StaffController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;

        public StaffController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }


        // GET: Staff
        public ActionResult Index()
        {

            return View(db.Staffs.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL STAFF
            List<Staff> staffs = db.Staffs.Include(s => s.Department).Include(s => s.hospital).ToList();


            return View(staffs);
        }

        public ActionResult Show(int id)
        {
            return RedirectToAction("Show/" + id);
        }
        public ActionResult Show(int? id)
        {
            if ((id == null) || (db.Staffs.Find(id) == null))
            {
                return NotFound();

            }
            string query = "select * from staff where staffid=@id";
            SqlParameter param = new SqlParameter("@id", id);

            var staffstoshow = db.Staffs.Include(s => s.Department).Include(s => s.hospital);

            return View(staffstoshow);
        }

        public ActionResult Create()
        {
            StaffEdit se = new StaffEdit();
            se.Departments = db.Departments.ToList();
            se.Hospitals = db.Hospitals.ToList();
            return View(se);
        }



        [HttpPost]
        public ActionResult Create(string StaffFirstName, string StaffLastName, string TypeDoctor, int DepartmentID,  int HospitalId)
        {


            //Query   
            string query = "insert into staffs ( StaffFirstName, StaffLastName, TypeDoctor, DepartmentID,  HospitalId) values (@sfn, @sln, @td, @depid,  @hid)";


            SqlParameter[] myparams = new SqlParameter[5];

            //myparams[0] = new SqlParameter("@sid", StaffId);

            myparams[0] = new SqlParameter("@sfn", StaffFirstName);

            myparams[1] = new SqlParameter("@sln", StaffLastName);

            myparams[2] = new SqlParameter("@td", TypeDoctor);

            myparams[3] = new SqlParameter("@depid", DepartmentID);

            myparams[4] = new SqlParameter("@hid", HospitalId);


            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }

        //public ActionResult Edit(int id)
        //{

        //    StaffEdit staffeditview = new StaffEdit();

        //    //Finds all hospitals
        //    staffeditview.Hospitals = db.Hospitals.ToList();
        //    //Finds all departments
        //    staffeditview.Departments = db.Departments.ToList();



        //    return View(staffeditview);
        //}

        //[HttpPost]
        //public ActionResult Edit(int StaffId, string StaffFirstName_New, string StaffLastName_New, int DepartmentId, string TypeDoctor, int HospitalId)
        //{

        //    if ((StaffId == null) || (db.Staff.Find(id) == null))
        //    {
        //        return NotFound();

        //    }
        //    //Raw Update MSSQL query

        //    string query = "update staffs set StaffId=@sid, StaffFirstName = @sfn, StaffLastName=@sln,  DepartmentId=@depid,TypeDoctor=@td, HospitalId=@hid where StaffId=@id";


        //    SqlParameter[] myparams = new SqlParameter[6];

        //    myparams[0] = new SqlParameter("@sid", StaffId);

        //    myparams[1] = new SqlParameter("@sfn", StaffFirstName_New);

        //    myparams[2] = new SqlParameter("@sln", StaffLastName_New);

        //    myparams[3] = new SqlParameter("@depid", DepartmentId);

        //    myparams[4] = new SqlParameter("@td", TypeDoctor);

        //    myparams[5] = new SqlParameter("@hid", HospitalId);


        //    //Execute the custom SQL command with parameters
        //    db.Database.ExecuteSqlCommand(query, myparams);

        //    //GOTO: View/Blog/Show.cshtml with paramter Blogid passed
        //    return RedirectToAction("Show/" + StaffId);
        //}

    }
}