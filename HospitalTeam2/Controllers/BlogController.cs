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
    public class BlogController : Controller
    {


        private readonly HospitalCMSContext _context;

        public BlogController(HospitalCMSContext context)
        {
            _context = context;
        }

        // GET: Blogs
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
        public ActionResult Create(string BlogTitle_new, string BlogDescription_new, string BlogAuthor_new, int BlogDate_new, int BlogTime_new)
        {
            string query = "insert into Events (BlogTitle,BlogDescription,BlogAuthor,BlogDate,BlogTime)"
                + "values (@title,@description,@author,@date,@time)";

            SqlParameter[] myparams = new SqlParameter[5];
            myparams[0] = new SqlParameter("@title", BlogTitle_new);
            myparams[1] = new SqlParameter("@description", BlogDescription_new);
            myparams[2] = new SqlParameter("@author", BlogAuthor_new);
            myparams[3] = new SqlParameter("@date", BlogDate_new);
            myparams[4] = new SqlParameter("@time", BlogTime_new);

            _context.Database.ExecuteSqlCommand(query, myparams);
            Debug.WriteLine(query);
            return RedirectToAction("List");

        }






        /*public IActionResult Index()
        {
            return View();
        }*/
    }
}
