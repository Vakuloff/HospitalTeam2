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
    public class AlertController : Controller
    {
        //makes a HospitalCMSContext
        private readonly HospitalCMSContext db;

        private readonly IHostingEnvironment _env;
        public AlertController(HospitalCMSContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(db.Alerts.ToList());
        }
        public ActionResult List()
        {
            //LIST WILL SHOW ALL STAFF
            List<Alert> alerts = db.Alerts.ToList();
            return View(alerts);
        }
        //public ActionResult Show(int? id)
        //{
        //    if ((id == null) || (db.Alerts.Find(id) == null))
        //    {
        //        return NotFound();
        //    }
        //    string query = "select * from Alerts where alertid=@id";
        //    SqlParameter param = new SqlParameter("@id", id);

        //    Alert alerttoshow = db.Alerts.SingleOrDefault(h => h.AlertId == id);
        //    return View(alerttoshow);
        //}
        [HttpPost]
        public ActionResult Create(string AlertTitle, string AlertMessage)
        {
            //Query   
            string query = "insert into alerts ( AlertTitle, AlertMessage) values (@at, @am)";

            SqlParameter[] myparams = new SqlParameter[2];

            myparams[0] = new SqlParameter("@at", AlertTitle);

            myparams[1] = new SqlParameter("@am", AlertMessage);


            db.Database.ExecuteSqlCommand(query, myparams);

            //GOTO: 
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {

            AlertEdit alerteditview = new AlertEdit();


            alerteditview.Alerts = db.Alerts.SingleOrDefault(h => h.AlertId == id);
            //GOTO: Views/Staff/Edit.cshtml
            return View(alerteditview);
        }
        [HttpPost]
        public ActionResult Edit(int? id, string AlertTitle_New, string AlertMessage_New)
        {

            if ((id == null) || (db.Alerts.Find(id) == null))
            {
                return NotFound();

            }
            //Raw Update MSSQL query

            string query = "update alerts set AlertTitle=@atn, AlertMessage=@amn where Alertid=@id";


            SqlParameter[] myparams = new SqlParameter[3];

            myparams[0] = new SqlParameter("@atn", AlertTitle_New);

            myparams[1] = new SqlParameter("@amn", AlertMessage_New);

            myparams[5] = new SqlParameter("@id", id);

            //Execute the custom SQL command with parameters
            db.Database.ExecuteSqlCommand(query, myparams);

            return RedirectToAction("Show/" + id);
        }
        // GET: Alert/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(400);
            }
            Alert alert = db.Alerts.Find(id);
            if (alert == null)
            {
                return NotFound();
            }
            return View(alert);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Alert alert = db.Alerts.Find(id);
            db.Alerts.Remove(alert);
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