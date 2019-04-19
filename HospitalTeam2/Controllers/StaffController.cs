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
using HospitalTeam2.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using HospitalTeam2.Models.ViewModels;

namespace HospitalTeam2.Controllers
{
    public class StaffController : Controller
    {

        private readonly HospitalCMSContext _context;

        public StaffController(HospitalCMSContext context)
        {
            _context = context;
        }

        // GET: find Staff
        public async Task<IActionResult> Find()
        {
            FindDoctorViewModel findDoctorViewModel = new FindDoctorViewModel();
            findDoctorViewModel.Departments = await _context.Departments.ToListAsync();
            foreach (var item in findDoctorViewModel.Departments)
            {
                item.Hospital = _context.Hospitals.FirstOrDefault(hospital => hospital.HospitalID == item.HospitalID);
            }
            return View(findDoctorViewModel);
        }

        public IActionResult Details(int id)
        {
            Staff staff =  _context.Staffs.FirstOrDefault(doc => doc.StaffId == id);
            staff.schedules = _context.Schedules.Where(sch => sch.StaffId == staff.StaffId).ToList();
            return View(staff);
        }

        [HttpPost]
        public async Task<IActionResult> Find(int[] DepartmentIds)
        {
            FindDoctorViewModel findDoctorViewModel = new FindDoctorViewModel();
            var hospitalList = _context.Hospitals.ToList();
            findDoctorViewModel.Departments = await _context.Departments.ToListAsync();
            foreach (var item in findDoctorViewModel.Departments)
            {
                item.Hospital = hospitalList.FirstOrDefault(hospital => hospital.HospitalID == item.HospitalID);
            }
            findDoctorViewModel.Doctors = new List<Staff>();
            findDoctorViewModel.DepartmentIds = DepartmentIds;
            foreach (var departmentId in DepartmentIds)
            {
                var staffList = _context.Staffs.Where(staff => staff.DepartmentID == departmentId);
                await staffList.ForEachAsync(staff =>
                 staff.Departments.Hospital = hospitalList.FirstOrDefault(hospital => hospital.HospitalID == staff.Departments.HospitalID));
                findDoctorViewModel.Doctors.AddRange(staffList);
            }

            return View(findDoctorViewModel);
        }

    }
}