using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalTeam2.Data;
using HospitalTeam2.Models;
using System.Data.SqlClient;

namespace HospitalTeam2.Controllers
{
    public class FAQsController : Controller
    {
        private readonly HospitalCMSContext db;

        public FAQsController(HospitalCMSContext context)
        {
            db = context;
        }

        // GET: FAQs
        public async Task<IActionResult> Index()
        {
            return View(await db.FAQs.ToListAsync());
        }

        // GET: FAQs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await db.FAQs
                .SingleOrDefaultAsync(m => m.FaqID == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // GET: FAQs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FAQs/Create
        
        [HttpPost]
        public ActionResult Create(string FAQ_NewA, string FAQ_NewQ)
        {
            string query = "insert into FAQs (FaqAns, FaqQues) values (@ans, @ques)";
            SqlParameter[] myparams = new SqlParameter[2];
            myparams[0] = new SqlParameter("@ans", FAQ_NewA);
            myparams[1] = new SqlParameter("@ques", FAQ_NewQ);

            db.Database.ExecuteSqlCommand(query, myparams);


            return RedirectToAction("Index");

        }

        // GET: FAQs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fAQ = await db.FAQs.SingleOrDefaultAsync(m => m.FaqID == id);
            if (fAQ == null)
            {
                return NotFound();
            }
            return View(fAQ);
        }

        // POST: FAQs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FaqID,FaqQues,FaqAns")] FAQ fAQ)
        {
            if (id != fAQ.FaqID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(fAQ);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQExists(fAQ.FaqID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fAQ);
        }

       
        public async Task<IActionResult> Delete(int? id)
        {
            if (db.FAQs.Find(id) == null)
            {
                return NotFound();
            }

            string query = "delete from FAQs where FaqID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            await db.Database.ExecuteSqlCommandAsync(query, param);
            return RedirectToAction("Index");

            
        }

        // POST: FAQs/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var fAQ = await db.FAQs.SingleOrDefaultAsync(m => m.FaqID == id);
        //    db.FAQs.Remove(fAQ);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool FAQExists(int id)
        {
            return db.FAQs.Any(e => e.FaqID == id);
        }
    }
}
