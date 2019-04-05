using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HospitalNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using HospitalTeam2.Data;

namespace HospitalNew.Controllers
{
    public class EventController : Controller
    {


        private readonly HospitalCMSContext _context;

        public EventController(HospitalCMSContext context)
        {
            _context = context;
        }

        // GET: Events
        public ActionResult Index()
        {
            //Redirect to the list view method
            return RedirectToAction("List");
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string EventName_new, string EventDescription_new, string EventLocation_new, int EventDate_new, int EventTime_new)
        {
            string query = "insert into Events (EventName,EventDescription,EventLocation,EventDate,EventTime)"
                + "values (@name,@description,@location,@date,@time)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@name", EventName_new);
            myparams[1] = new SqlParameter("@description", EventDescription_new);
            myparams[2] = new SqlParameter("@location", EventLocation_new);
            myparams[3] = new SqlParameter("@date", EventDate_new);
            myparams[4] = new SqlParameter("@time", EventTime_new);

            _context.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
            return RedirectToAction("List");

        }






       /* public IActionResult Index()
        {
            return View();
        }*/
    }
}