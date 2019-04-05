using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HospitalNew.Models;
using HospitalTeam2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalNew.Controllers
{
    public class FeedbackController : Controller
    {



        private readonly HospitalCMSContext _context;

        public FeedbackController(HospitalCMSContext context)
        {
            _context = context;
        }

        // GET: Feedbacks
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
        public ActionResult Create(string FullName_new, string FeedbacksEmail_new, string ContactNumber_new, int FeedbacksSubject_new, int FeedbacksMessage_new)
        {
            string query = "insert into Feedback (FullName,FeedbacksEmail,ContactNumber,FeedbacksSubject,FeedbacksMessage)"
                + "values (@FullName,@FeedbacksEmail,@ContactNumber,@FeedbacksSubject,@FeedbacksMessage)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@title", FullName_new);
            myparams[1] = new SqlParameter("@description", FeedbacksEmail_new);
            myparams[2] = new SqlParameter("@author", ContactNumber_new);
            myparams[3] = new SqlParameter("@date", FeedbacksSubject_new);
            myparams[4] = new SqlParameter("@time", FeedbacksMessage_new);

            _context.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
            return RedirectToAction("List");

        }


        public ActionResult List()
         {


         return View(_context.Feedbacks.ToList());
        }










        /* public IActionResult Index()
         {
             return View();
         }*/
    }
}